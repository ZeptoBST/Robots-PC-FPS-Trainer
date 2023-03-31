using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace Blast_trainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Mem m = new Mem();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                int pID = m.GetProcIdFromName("Robots");   //  ZInfo: get proc id of game

                bool openProc = false;  // ZInfo: Is process open?

                if (pID > 0) openProc = m.OpenProcess(pID); // ZInfo: Try opening process if proc ID is greater than 1.

                if (openProc)   // ZInfo: If process open, do code
                {
                    if (lives.Checked) m.WriteMemory("0x0047289E", "bytes", "90 90 90 90 90"); // ZInfo: If checked, force lives counter at 10.
                    if (lives.Checked) m.WriteMemory("Robots.exe+0x220020", "byte", "0x3C");
                    //else m.WriteMemory("0x004D0327", "byte", "0x0A"); // ZInfo: Not needed, but would force a different value if it was a on or off switch, kinda.
                }
            }
        }

        private void lives_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
