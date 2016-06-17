using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_Viewer
{
    public partial class ViewerForm : Form
    {
        public ViewerForm()
        {
            InitializeComponent();
        }

        private void btnSelectPicture_Click(object sender, EventArgs e)
        {
            //Show the open file dialog box.
            if (ofdSelectPicture.ShowDialog() == DialogResult.OK)
            {
                //Load the picture into the box.
                picShowPicture.Image = Image.FromFile(ofdSelectPicture.FileName);
                //Show the name of the file in the forms caption
                this.Text = string.Concat("Picture Viewer(" + ofdSelectPicture.FileName + ")");

            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //Close the window and exit the application.
            this.Close();

        }

        private void ofdSelectPicture_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void picShowPicture_Click(object sender, EventArgs e)
        {

        }

        private void btnEnlarge_Click(object sender, EventArgs e)
        {
            this.Width = this.Width + 20;
            this.Height = this.Height + 20;

        }


        private void btnShrink_Click(object sender, EventArgs e)
        {
            this.Width = this.Width - 20;
            this.Height = this.Height - 20;
        }

        private void btnDrawBorder_Click(object sender, EventArgs e)
        {
            Graphics objGraphics = null;
            objGraphics = this.CreateGraphics();
            objGraphics.Clear(SystemColors.Control);
            objGraphics.DrawRectangle(Pens.Blue,
                picShowPicture.Left - 1, picShowPicture.Top - 1,
                picShowPicture.Width + 1, picShowPicture.Height + 1);
            objGraphics.Dispose();


        }

        private void picShowPicture_MouseMove(object sender, MouseEventArgs e)
        {
            lblX.Text = "X: " + e.X.ToString();
            lblY.Text = "Y: " + e.Y.ToString();

        }

        private void picShowPicture_MouseLeave(object sender, EventArgs e)
        {
            lblX.Text = "";
            lblY.Text = "";
        }

        private void ViewerForm_Load(object sender, EventArgs e)
        {
            lblX.Text = "";
            lblY.Text = "";
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionsForms frmOptionsDialog = new OptionsForms();
            frmOptionsDialog.ShowDialog();
        }

        private void mnuOpenPicture_Click(object sender, EventArgs e)
        {
            //Show the open file dialog box
            if (ofdSelectPicture.ShowDialog() == DialogResult.OK)
            {
                // Load the picture into the picture box.
                picShowPicture.Image = Image.FromFile(ofdSelectPicture.FileName);
                // Show the name of the file in the form's caption.
                this.Text = string.Concat("Picture Viewer(" +
                    ofdSelectPicture.FileName + ")");
            }
        }

        private void mnuConfirmOnExit_Click(object sender, EventArgs e)
        {
            mnuConfirmOnExit.Checked = !(mnuConfirmOnExit.Checked);
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuDrawBorder_Click(object sender, EventArgs e)
        {
            Graphics objGraphics = null;
            objGraphics = this.CreateGraphics();
            objGraphics.Clear(SystemColors.Control);
            objGraphics.DrawRectangle(Pens.Blue,
                picShowPicture.Left - 1, picShowPicture.Top - 1,
                picShowPicture.Width + 1, picShowPicture.Height + 1);
            objGraphics.Dispose();
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            OptionsForms frmOptionsDialog = new OptionsForms();
            frmOptionsDialog.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void drawBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics objGraphics = null;
            objGraphics = this.CreateGraphics();
            objGraphics.Clear(SystemColors.Control);
            objGraphics.DrawRectangle(Pens.Blue,
                picShowPicture.Left - 1, picShowPicture.Top - 1,
                picShowPicture.Width + 1, picShowPicture.Height + 1);
            objGraphics.Dispose();
        }

        private void tbbOpenPicture_Click(object sender, EventArgs e)
        {
            //Show the open file dialog box
            if (ofdSelectPicture.ShowDialog() == DialogResult.OK)
            {
                // Load the picture into the picture box.
                picShowPicture.Image = Image.FromFile(ofdSelectPicture.FileName);
                // Show the name of the file in the form's caption.
                this.Text = string.Concat("Picture Viewer(" +
                    ofdSelectPicture.FileName + ")");
            }


        }

        private void tbbDrawBorder_Click(object sender, EventArgs e)
        {
            Graphics objGraphics = null;
            objGraphics = this.CreateGraphics();
            objGraphics.Clear(SystemColors.Control);
            objGraphics.DrawRectangle(Pens.Blue,
                picShowPicture.Left - 1, picShowPicture.Top - 1,
                picShowPicture.Width + 1, picShowPicture.Height + 1);
            objGraphics.Dispose();
        }

        private void tbbOptions_Click(object sender, EventArgs e)
        {
            OptionsForms frmOptionsDialog = new OptionsForms();
            frmOptionsDialog.ShowDialog();
        }
    }
}