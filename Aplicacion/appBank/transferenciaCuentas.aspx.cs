using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class transferenciaCuentas : System.Web.UI.Page
{
    Conexion con = new Conexion();
    List<Datos> cuenta;
    double valorActual;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if (Session["idUsu"] == null)
            {
                Response.Redirect("iniciarSesion.aspx");
            }
            if (Session["rolUsu"].ToString().Equals("1"))
            {
                Response.Redirect("iniciarSesion.aspx");
            }
            String encabezado = "No. Cuenta: " + Session["idCuenta"].ToString() + " Nombre: "+ Session["nombreUsu"].ToString()+" codigo: "+ Session["idUsu"].ToString();
            nombre_usuario.Text = encabezado;
            
        }
        this.cuenta = con.datosCuenta("SELECT * FROM Cuenta WHERE idCuenta=" + Session["idCuenta"].ToString() + ";");
        this.valorActual = Convert.ToDouble(cuenta[0].dato2.ToString());
        saldoActual.Text = "Saldo actual: Q " + valorActual.ToString("N2");
    }

    protected void boton_Click(object sender, EventArgs e)
    {
        switch (Convert.ToInt64(DropDownList1.SelectedValue.ToString()))
        {
            case 1: //Deposito
                double dinero = Convert.ToDouble(monto.Text);
                this.cuenta = con.datosCuenta("SELECT * FROM Cuenta WHERE idCuenta=" + Session["idCuenta"].ToString() + ";");
                this.valorActual = Convert.ToDouble(cuenta[0].dato2.ToString());
                
                valorActual = valorActual + dinero;
                saldoActual.Text = "Saldo actual: Q " + valorActual.ToString("N2");
                con.Ejecutar201503984("UPDATE Cuenta SET saldo = " + valorActual.ToString("N2") + " WHERE idCuenta = " + Session["idCuenta"].ToString() + ";");
                Response.Write("<script>window.alert('El deposito se realizo con exito.');</script>");
                break;
            case 2: //Retiro
                dinero = Convert.ToDouble(monto.Text);
                this.cuenta = con.datosCuenta("SELECT * FROM Cuenta WHERE idCuenta=" + Session["idCuenta"].ToString() + ";");
                this.valorActual = Convert.ToDouble(cuenta[0].dato2.ToString());

                if (valorActual >= dinero)
                {
                    valorActual = valorActual - dinero;
                    saldoActual.Text = "Saldo actual: Q " + valorActual.ToString("N2");
                    con.Ejecutar201503984("UPDATE Cuenta SET saldo = " + valorActual.ToString("N2") + " WHERE idCuenta = " + Session["idCuenta"].ToString() + ";");
                    Response.Write("<script>window.alert('El retiro se realizo con exito.');</script>");
                }
                else
                {
                    Error.Text = "ERROR: No cuenta con el saldo suficiente para realizar esta transaccion.";
                }
                break;
            case 0: //transferencia entre cuentas
                List<Datos> cuenta_2 = con.datosCuenta("SELECT * FROM Cuenta WHERE idCuenta=" + cuenta2.Text + ";");

                try
                {
                    if (cuenta_2.Count != 0)
                    {
                        if (!Session["idCuenta"].ToString().Equals(cuenta2.Text))
                        {
                            double montoAumenta = Convert.ToDouble(cuenta_2[0].dato2);
                            dinero = Convert.ToDouble(monto.Text);

                            this.cuenta = con.datosCuenta("SELECT * FROM Cuenta WHERE idCuenta=" + Session["idCuenta"].ToString() + ";");
                            this.valorActual = Convert.ToDouble(cuenta[0].dato2.ToString());

                            if (valorActual >= dinero)
                            {
                                valorActual = valorActual - dinero;
                                montoAumenta = montoAumenta + dinero;
                                saldoActual.Text = "Saldo actual: Q " + valorActual.ToString("N2");
                                con.Ejecutar201503984("UPDATE Cuenta SET saldo = " + valorActual.ToString("N2") + " WHERE idCuenta = " + Session["idCuenta"].ToString() + ";");
                                con.Ejecutar201503984("UPDATE Cuenta SET saldo = " + montoAumenta.ToString("N2") + " WHERE idCuenta = " + cuenta_2[0].dato1.ToString() + ";");
                                Response.Write("<script>window.alert('La transferencia se realizo con exito.');</script>");
                            }
                            else
                            {
                                Error.Text = "ERROR: No cuenta con el saldo suficiente para realizar esta transaccion.";
                            }
                        }
                        else
                        {
                            Error.Text = "ERROR: Debe de ingresar un numero de cuenta diferente a la suya.";
                        }
                    }
                    else
                    {
                        Error.Text = "ERROR: la cuenta receptor no existe.";
                    }
                }
                catch (Exception)
                {
                    Error.Text = "ERROR: Transaccion no realizada";
                }
                break;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch(Convert.ToInt64(DropDownList1.SelectedValue.ToString()))
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
}