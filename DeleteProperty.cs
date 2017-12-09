using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Windows.Forms;

namespace DeleteProperties
{
    public class DeleteProperty
    {
        private ModelDoc2 _swModel;
        private CustomPropertyManager _propManager;
        private SldWorks _swApp = new SldWorks();
        private ModelDocExtension _swModelExt;
        private String[] _propNames = null;
        private int _propCount;

        public DeleteProperty()
        {            
        }

        //Gets the property names
        public object[] getCustomPropNames()
        {
            if (_swApp.ActiveDoc == null)
            {
                String message = "SolidWorks does not have an open document.";
                String caption = "SolidWorks Error";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, button);
            }
            else
            {
                _swModel = _swApp.ActiveDoc;
                _swModelExt = _swModel.Extension;
                _propManager = _swModelExt.get_CustomPropertyManager("");
                _propCount = _propManager.Count;
            }
            _propNames = _propManager.GetNames();
            return _propNames;
        }

        //Deletes specific properties
        public void deleteProperty(String propName)
        {
            //Go through all the property names
            for (int i = 0; i < _propCount; i++)
            {
                //Current propertyName
                String tempPropName = _propNames.GetValue(i).ToString();
                //Verify that the property name contains the input
                bool contains = tempPropName.IndexOf(propName, StringComparison.OrdinalIgnoreCase) >= 0;
                if (contains)
                {
                    //Delete custom property
                    _propManager.Delete2(tempPropName);
                }
            }
            String message = "Property has been deleted!";
            String caption = "SolidWorks Message";
            MessageBoxButtons button = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, button);
        }

        //Check if property exists
        public bool propExists(String propName)
        {
            bool contains = false;
            for (int i = 0; i < _propCount; i++)
            {
                //Current propertyName
                String tempPropName = _propNames.GetValue(i).ToString();
                //Verify that the property name contains the input
                contains = tempPropName.IndexOf(propName, StringComparison.OrdinalIgnoreCase) >= 0;
                if (contains)
                {
                    return contains;
                }
            }
            return contains;
        }

        /// <summary>
        /// Checks the SW document type
        /// </summary>
        /// <returns>{1} If the document is a part or assembly. {0} If the document is a drawing</returns>
        public int _canDeleteProperties()
        {
            if (_swApp.ActiveDoc != null)
            {
                if (((ModelDoc2)_swApp.ActiveDoc).GetType() == (int)swDocumentTypes_e.swDocASSEMBLY ||
                    ((ModelDoc2)_swApp.ActiveDoc).GetType() == (int)swDocumentTypes_e.swDocPART)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
