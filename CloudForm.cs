using System;
using System.Drawing;
using System.Windows.Forms;
using TagsCloudForm.Common;
using TagsCloudForm.UiActions;

namespace TagsCloudForm
{
    public class CloudForm : Form
    {

        public CloudForm(IUiAction[] actions, PictureBoxImageHolder pictureBox,
            ImageSettings imageSettings)
        {
            ClientSize = new Size(imageSettings.Width, imageSettings.Height);
            var mainMenu = new MenuStrip();
            mainMenu.Items.AddRange(actions.ToMenuItems());
            Controls.Add(mainMenu);
            pictureBox.RecreateImage(imageSettings);
            pictureBox.Dock = DockStyle.Fill;
            Controls.Add(pictureBox);
        }

        private void CloudForm_ResizeEnd(object sender, EventArgs e)
        {
            Console.WriteLine("aaa");
            // Your code here
        }
        
        
        private void CloudForm_Resize(object sender, System.EventArgs e)
        {
            Console.WriteLine("resize");
            Control control = (Control)sender;
            control.Size = new Size(100, 100);

            // Ensure the Form remains square (Height = Width).
            //if(control.Size.Height != control.Size.Width)
            //{
            //    control.Size = new Size(control.Size.Width, control.Size.Width);
            //}
        }
    }
}
