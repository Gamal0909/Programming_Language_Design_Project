using com.calitha.goldparser;

namespace PLDProject
{
    public partial class Form1 : Form
    {
        MyParser parser;
        public Form1()
        {
            InitializeComponent();
            parser = new MyParser("Grammer.cgt", Output,LSB);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            Output.Items.Clear();
            LSB.Items.Clear();
            parser.Parse(input.Text);
        }
    }
}
