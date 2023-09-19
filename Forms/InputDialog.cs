namespace AnjinFilesTool.Forms
{
    public partial class InputDialog : Form
    {
        public InputDialog()
        {
            InitializeComponent();
        }

        public static DialogResult ShowInputDialog(Form owner, ref string input)
        {
            InputDialog dialog = new InputDialog();
            dialog.input.Text = input;
            DialogResult result = dialog.ShowDialog();
            input = dialog.input.Text;
            return result;
        }
    }

}
