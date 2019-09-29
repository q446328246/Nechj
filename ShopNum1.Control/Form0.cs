using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using TabControl = ShopNum1.Control.TabControl;

internal class Form0 : WindowsFormsComponentEditor
{
    private bool EditComponent(ITypeDescriptorContext context, object component, IWin32Window owner)
        //WindowsFormsComponentEditor
    {
        var control = (TabControl) component;
        IServiceProvider site = control.Site;
        IComponentChangeService service = null;
        DesignerTransaction transaction = null;
        bool flag = false;
        try
        {
            if (site != null)
            {
                transaction =
                    ((IDesignerHost) site.GetService(typeof (IDesignerHost))).CreateTransaction("BuildTabStrip");
                service = (IComponentChangeService) site.GetService(typeof (IComponentChangeService));
                if (service != null)
                {
                    try
                    {
                        service.OnComponentChanging(component, null);
                    }
                    catch (CheckoutException exception)
                    {
                        if (exception != CheckoutException.Canceled)
                        {
                            throw exception;
                        }
                        return false;
                    }
                }
            }
            try
            {
                var form = new TabEditorForm(control);
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    flag = true;
                }
            }
            finally
            {
                if (flag && (service != null))
                {
                    service.OnComponentChanged(control, null, null, null);
                }
            }
        }
        finally
        {
            if (transaction != null)
            {
                if (flag)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Cancel();
                }
            }
        }
        return flag;
    }
}