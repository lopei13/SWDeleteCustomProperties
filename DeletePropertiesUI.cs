using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DeleteProperties
{
    [ProgId(DeleteProperties.TaskPaneIntergration._SWTASKPANE_PROGID)]
    public partial class DeletePropertiesUI : UserControl
    {
        private object[] _propNames;
        private String _propToDelete;
        private DeleteProperty _props = new DeleteProperty();

        public DeletePropertiesUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_props._canDeleteProperties() < 1)
            {
                String message = "SolidWorks does not have an open document.";
                String caption = "SolidWorks Error";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, button);
            }
            else
            {
                _propNames = _props.getCustomPropNames();
            }
        }

        private void DeletePropertiesUI_Load(object sender, EventArgs e)
        {

        }

        private void PropertyToDelete_TextBx_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            _propToDelete = objTextBox.Text;
        }

        private void DeleteProperties_Button_Click(object sender, EventArgs e)
        {
            if (_props._canDeleteProperties() < 1)
            {
                String message = "SolidWorks does not have an open document.";
                String caption = "SolidWorks Error";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, button);
            }
            else if (_propNames == null)
            {
                String message = "You need to select Get Custom Properties.";
                String caption = "SolidWorks Error";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, button);
            }
            else
            {
                if (!_props.propExists(_propToDelete))
                {
                    DoesntExist.Visible = true;
                }
                else
                {
                    DoesntExist.Visible = false;
                    _props.deleteProperty(_propToDelete);
                }
            }            
        }
    }
}
