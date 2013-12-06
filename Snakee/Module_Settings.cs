using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snakee
{
    public partial class frmSettings
    {

        #region Dock

        void Content_Dock(Control dock)
        {
            dock.Dock = DockStyle.Fill;
            //dock.BringToFront();
        }

        #endregion

    }
}
