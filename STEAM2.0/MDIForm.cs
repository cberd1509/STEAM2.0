using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STEAM2._0
{
    public class MDIForm : Form
    {

        public string nombre { get; set; }
        public string type { get; set; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MDIForm
            // 
            this.ClientSize = new System.Drawing.Size(610, 415);
            this.Name = "MDIForm";
            this.ResumeLayout(false);

        }
    }
}
