namespace DeleteProperties
{
    partial class DeletePropertiesUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GetCustomProps_Button = new System.Windows.Forms.Button();
            this.PropertyToDelete_TextBx = new System.Windows.Forms.TextBox();
            this.DeleteProperties_Button = new System.Windows.Forms.Button();
            this.DoesntExist = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GetCustomProps_Button
            // 
            this.GetCustomProps_Button.AccessibleName = "GetCustomProperties";
            this.GetCustomProps_Button.Location = new System.Drawing.Point(15, 34);
            this.GetCustomProps_Button.Name = "GetCustomProps_Button";
            this.GetCustomProps_Button.Size = new System.Drawing.Size(117, 39);
            this.GetCustomProps_Button.TabIndex = 0;
            this.GetCustomProps_Button.Text = "Get Custom Properties";
            this.GetCustomProps_Button.UseVisualStyleBackColor = true;
            this.GetCustomProps_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // PropertyToDelete_TextBx
            // 
            this.PropertyToDelete_TextBx.AccessibleName = "PropertyToDelete";
            this.PropertyToDelete_TextBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyToDelete_TextBx.Location = new System.Drawing.Point(160, 34);
            this.PropertyToDelete_TextBx.Multiline = true;
            this.PropertyToDelete_TextBx.Name = "PropertyToDelete_TextBx";
            this.PropertyToDelete_TextBx.Size = new System.Drawing.Size(100, 39);
            this.PropertyToDelete_TextBx.TabIndex = 1;
            this.PropertyToDelete_TextBx.TextChanged += new System.EventHandler(this.PropertyToDelete_TextBx_TextChanged);
            // 
            // DeleteProperties_Button
            // 
            this.DeleteProperties_Button.Location = new System.Drawing.Point(90, 95);
            this.DeleteProperties_Button.Name = "DeleteProperties_Button";
            this.DeleteProperties_Button.Size = new System.Drawing.Size(112, 43);
            this.DeleteProperties_Button.TabIndex = 2;
            this.DeleteProperties_Button.Text = "Delete Custom Properties";
            this.DeleteProperties_Button.UseVisualStyleBackColor = true;
            this.DeleteProperties_Button.Click += new System.EventHandler(this.DeleteProperties_Button_Click);
            // 
            // DoesntExist
            // 
            this.DoesntExist.AutoSize = true;
            this.DoesntExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoesntExist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DoesntExist.Location = new System.Drawing.Point(64, 141);
            this.DoesntExist.Name = "DoesntExist";
            this.DoesntExist.Size = new System.Drawing.Size(165, 20);
            this.DoesntExist.TabIndex = 4;
            this.DoesntExist.Text = "Property Doesn\'t Exist";
            this.DoesntExist.Visible = false;
            // 
            // DeletePropertiesUI
            // 
            this.AccessibleName = "GetCustomProperties";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DoesntExist);
            this.Controls.Add(this.DeleteProperties_Button);
            this.Controls.Add(this.PropertyToDelete_TextBx);
            this.Controls.Add(this.GetCustomProps_Button);
            this.Name = "DeletePropertiesUI";
            this.Size = new System.Drawing.Size(318, 177);
            this.Load += new System.EventHandler(this.DeletePropertiesUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetCustomProps_Button;
        private System.Windows.Forms.TextBox PropertyToDelete_TextBx;
        private System.Windows.Forms.Button DeleteProperties_Button;
        private System.Windows.Forms.Label DoesntExist;
    }
}
