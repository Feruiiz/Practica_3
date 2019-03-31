using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class appBank_aprobarCreditos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (Convert.ToInt64(DropDownList1.SelectedValue.ToString()))
        {
            case 0: //transferencia entre cuentas
                cuenta2.Visible = true;
                break;
            case 1: //Deposito
                cuenta2.Visible = false;
                break;
            case 2: //Retiro
                cuenta2.Visible = false;
                break;
        }
    }

    protected void boton_Click(object sender, EventArgs e)
    {

    }
}