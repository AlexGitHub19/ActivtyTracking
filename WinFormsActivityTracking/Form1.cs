using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsActivityTracking
{
    public partial class Form1 : Form
    {
        KeyboardHook keyboardHook;
        MouseHook mouseHook;
        public Form1()
        {
            InitializeComponent();

            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += new KeyboardHook.KeyboardHookCallback(keyboardHook_KeyDown);
            keyboardHook.Install();

            mouseHook = new MouseHook();
            mouseHook.MouseMove += new MouseHook.MouseHookCallback(mouseHook_MouseMove);
            mouseHook.Install();

        }

        private void mouseHook_MouseMove(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            textBox1.Text += String.Format("Mouse coordinates: x-{0}, y-{1}", mouseStruct.pt.x, mouseStruct.pt.y) + Environment.NewLine;
        }

        private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            textBox1.Text += key.ToString() + Environment.NewLine;
        }

        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void HookKeyDown(object sender, KeyEventArgs e)
        {

            textBox1.Text += ((char)e.KeyValue).ToString() + Environment.NewLine;
        }


        private void HookMouseActivity(object sender, MouseEventArgs e)
        {

            textBox1.Text += "Mouse Coordinates" + e.X + ", " + e.Y + Environment.NewLine;
        }

    }
}
