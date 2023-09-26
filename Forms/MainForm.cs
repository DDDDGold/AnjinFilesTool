

using AnjinFilesTool.Core;
using AnjinFilesTool.Event.Events;
using AnjinFilesTool.Forms;
using System.Runtime.InteropServices;
using System.Text;

namespace AnjinApplication
{
    public partial class MainForm : Form
    {
        private FileManager _fileManager;
        private string _title = "暗金的文件小工具";
        public MainForm()
        {
            InitializeComponent();
            _fileManager = FileManager.Instance;
        }

        private void suppressFilterClose(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
                //((ToolStripDropDownMenu)sender).Invalidate();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FilePathResetEvent.EventHandler.RegisterListener(OnPathReset);
            FilesChangedEvent.EventHandler.RegisterListener(OnFilesChanged);
            FunctionProcessEvent.EventHandler.RegisterListener(OnFunctionProcess);
            FunctionDoneEvent.EventHandler.RegisterListener(OnFunctionDone);
            srcText.Text = _fileManager.Path;
            warningText.Text = null;
            foreach (var item in _fileManager.Files)
            {
                fileListBox.Items.Add(item.Name);
            }
            searchTypeBox.SelectedIndex = 0;
        }


        private void OnFunctionProcess(FunctionProcessEvent e)
        {
            stateText.Text = e.Info;
            processBar.Value = (int)(e.CurrentProgress * processBar.Maximum);
        }

        private void OnFunctionDone(FunctionDoneEvent e)
        {
            processBar.Value = 0;
            if (e.Result == FunctionDoneEvent.FunctionResult.Success)
            {
                stateText.Text = "操作成功";
            }
            else
            {
                stateText.Text = "操作未成功";
                StringBuilder sb = new StringBuilder();
                sb.Append("发生了以下错误:");
                e.Errors.ForEach(s => sb.Append('\n').Append(s));
                MessageBox.Show(sb.ToString());
            }
        }
        private void OnFilesChanged(FilesChangedEvent e)
        {
            if (e.IsChanged)
            {
                Text = _title + "*(未保存)";
                refresh();
            }
            else
            {
                Text = _title;
            }
        }

        private void refresh()
        {
            fileListBox.Items.Clear();
            foreach (var item in _fileManager.Files)
            {
                fileListBox.Items.Add(item.Name);
            }
        }

        private void OnPathReset(FilePathResetEvent e)
        {
            fileListBox.Items.Clear();
            if (e.Result.IsSuccess())
            {
                srcText.Text = e.Path;
                warningText.Text = null;
                refresh();
            }
            else
            {
                srcText.Text = null;
                if (e.Result == FilePathResetEvent.ActionResult.FILE_NOT_EXIST)
                {
                    warningText.Text = "文件不存在!";
                }
                else if (e.Result == FilePathResetEvent.ActionResult.IS_NOT_DIRECTORY)
                {
                    warningText.Text = "文件夹不存在!";
                }
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            _fileManager.Save();
            MessageBox.Show("保存成功");
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            warningText.Text = null;
            string match = searchTb.Text;
            if (!string.IsNullOrEmpty(match))
            {
                fileListBox.ClearSelected();
                for (int i = 0; i < fileListBox.Items.Count; i++)
                {
                    if (_fileManager.IsMatch(fileListBox.Items[i].ToString() ?? "", match))
                    {
                        fileListBox.SetSelected(i, true);
                    }
                }
            }
            else
            {
                warningText.Text = "检索关键词为空!";
            }
        }

        private void replaceBtn_Click(object sender, EventArgs e)
        {
            warningText.Text = null;
            string match = searchTb.Text;
            string to = replaceTb.Text;
            if (string.IsNullOrEmpty(match))
            {
                warningText.Text = "检索关键词为空!";
            }
            else if (string.IsNullOrEmpty(to))
            {
                warningText.Text = "替换文本为空!";
            }
            else
            {
                _fileManager.ReplaceFileName(match, to);
                refresh();
            }
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            if (!_fileManager.Changed || saveWarning())
            {
                FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
                openFileDialog.InitialDirectory = _fileManager.Path;
                DialogResult result = openFileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    _fileManager.ResetPath(openFileDialog.SelectedPath);
                }
            }

        }

        private bool saveWarning()
        {
            return MessageBox.Show("你有改动没有保存,是否继续并取消保存?", "aa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int mouseevent, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;

        private void fileListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SetCursorPos(Control.MousePosition.X, Control.MousePosition.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                rightClickMenu.Show(fileListBox, new Point(e.X, e.Y));
            }
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            if (!_fileManager.Changed || saveWarning())
            {
                _fileManager.ResetPath(_fileManager.Path);
            }
        }


        private void renameMenuItem_Click(object sender, EventArgs e)
        {
            if (fileListBox.Items.Count > 0 && fileListBox.SelectedItems.Count > 0)
            {
                int index = fileListBox.SelectedIndex;
                string name = (fileListBox.Items[index].ToString() ?? "").ToString();
                DialogResult result = InputDialog.ShowInputDialog(this, ref name);
                if (result == DialogResult.OK)
                {
                    _fileManager.SetFileName(index, name);
                    refresh();
                }
            }
        }

        private void openByExplorer_Click(object sender, EventArgs e)
        {
            if (fileListBox.Items.Count > 0 && fileListBox.SelectedIndex >= 0)
            {
                string argument = "/select, \"" + _fileManager.Files[fileListBox.SelectedIndex].File.FullName + "\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
            else
            {
                var psi = new System.Diagnostics.ProcessStartInfo() { FileName = _fileManager.Path, UseShellExecute = true };
                System.Diagnostics.Process.Start(psi);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_fileManager.Changed && !saveWarning())
            {
                e.Cancel = true;
            }
        }

        private void skipFolderMenuItem_Click(object sender, EventArgs e)
        {
            if (!_fileManager.Changed || saveWarning())
            {
                bool current = skipFolderMenuItem.Checked;
                skipFolderMenuItem.Checked = !current;
                if (current)
                {
                    _fileManager.RemoveFilter(FileManager.SkipDirectory);
                }
                else
                {
                    _fileManager.AddFilter(FileManager.SkipDirectory);
                }
                refresh();
            }
        }

        private void searchTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = SearchType.STRING;
            switch (searchTypeBox.SelectedIndex)
            {
                case 0: type = SearchType.STRING; break;
                case 1: type = SearchType.REGEX; break;
            }
            _fileManager.SearchType = type;
        }
    }
}