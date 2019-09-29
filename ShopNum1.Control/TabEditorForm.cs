using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ShopNum1.Control;
using Button = System.Windows.Forms.Button;
using TabControl = ShopNum1.Control.TabControl;
using TabPage = ShopNum1.Control.TabPage;

internal class TabEditorForm : Form
{
    private readonly TabControl tabControl_0;
    private Button button3;
    private Button cancel;
    private Button delnode;
    private IContainer icontainer_0;
    private PropertyGrid propertyGrid1;
    private Button save;
    public TabPageCollection tabPageCollection_0;
    private ToolTip toolTip_0;
    private TreeView treeView1;

    public TabEditorForm(TabControl tabControl_1)
    {
        InitializeComponent();
        tabControl_0 = tabControl_1;
        tabPageCollection_0 = tabControl_1.Items;
        foreach (TabPage page in tabPageCollection_0)
        {
            var node = new TreeNode(page.Caption);
            method_0(page, node);
            treeView1.Nodes.Add(node);
        }
        treeView1.HideSelection = false;
    }

    private void button3_Click(object sender, EventArgs e)
    {
        var pTab = new TabPage
            {
                Caption = "新属性页"
            };
        tabPageCollection_0.Add(pTab);
        var node = new TreeNode("新属性页")
            {
                Tag = pTab
            };
        treeView1.Nodes.Add(node);
        treeView1.SelectedNode = treeView1.Nodes[treeView1.Nodes.Count - 1];
    }

    private void cancel_Click(object sender, EventArgs e)
    {
        base.DialogResult = DialogResult.Cancel;
        base.Close();
    }

    private void delnode_Click(object sender, EventArgs e)
    {
        if (treeView1.SelectedNode != null)
        {
            var tag = (TabPage) treeView1.SelectedNode.Tag;
            tabControl_0.Items.Remove(tag);
            treeView1.SelectedNode.Remove();
        }
    }

    private void InitializeComponent()
    {
        icontainer_0 = new Container();
        treeView1 = new TreeView();
        propertyGrid1 = new PropertyGrid();
        save = new Button();
        cancel = new Button();
        button3 = new Button();
        delnode = new Button();
        toolTip_0 = new ToolTip(icontainer_0);
        base.SuspendLayout();
        treeView1.Location = new Point(12, 0x2c);
        treeView1.Name = "treeView1";
        treeView1.Size = new Size(0x133, 310);
        treeView1.TabIndex = 0;
        treeView1.AfterSelect += treeView1_AfterSelect;
        propertyGrid1.LineColor = SystemColors.ScrollBar;
        propertyGrid1.Location = new Point(0x150, 1);
        propertyGrid1.Name = "propertyGrid1";
        propertyGrid1.Size = new Size(0x146, 0x161);
        propertyGrid1.TabIndex = 1;
        propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
        save.Location = new Point(0x1b0, 0x173);
        save.Name = "save";
        save.Size = new Size(0x6a, 0x19);
        save.TabIndex = 2;
        save.Text = " 保 存 ";
        save.Click += save_Click;
        cancel.Location = new Point(0x22d, 0x173);
        cancel.Name = "cancel";
        cancel.Size = new Size(0x69, 0x19);
        cancel.TabIndex = 3;
        cancel.Text = " 取 消 ";
        cancel.Click += cancel_Click;
        button3.Location = new Point(12, 1);
        button3.Name = "button3";
        button3.Size = new Size(0x65, 0x22);
        button3.TabIndex = 4;
        button3.Text = "添加属性页";
        toolTip_0.SetToolTip(button3, "添加属性页");
        button3.Click += button3_Click;
        delnode.Location = new Point(130, 1);
        delnode.Name = "delnode";
        delnode.Size = new Size(0x57, 0x22);
        delnode.TabIndex = 6;
        delnode.Text = "删除属性页";
        toolTip_0.SetToolTip(delnode, "删除属性页");
        delnode.Click += delnode_Click;
        AutoScaleBaseSize = new Size(6, 14);
        base.ClientSize = new Size(0x2ab, 0x18e);
        base.Controls.Add(delnode);
        base.Controls.Add(button3);
        base.Controls.Add(cancel);
        base.Controls.Add(save);
        base.Controls.Add(propertyGrid1);
        base.Controls.Add(treeView1);
        base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        base.Name = "TabEditorForm";
        Text = "DiscuzNT TabPage Designer";
        base.ResumeLayout(false);
    }

    private void method_0(TabPage tabPage_0, TreeNode treeNode_0)
    {
        treeNode_0.Tag = tabPage_0;
        foreach (TabPage page in tabPage_0.Controls)
        {
            var node = new TreeNode(page.Caption);
            method_0(page, node);
            treeNode_0.Nodes.Add(node);
        }
    }

    private void propertyGrid1_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
    {
        if (e.ChangedItem.Label == "Caption")
        {
            treeView1.SelectedNode.Text = (string) e.ChangedItem.Value;
        }
    }

    private void save_Click(object sender, EventArgs e)
    {
        base.DialogResult = DialogResult.OK;
        base.Close();
    }

    //void Form.Dispose(bool disposing)
    //{
    //    if (disposing && (this.icontainer_0 != null))
    //    {
    //        this.icontainer_0.Dispose();
    //    }
    //    base.Dispose(disposing);
    //}

    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
        propertyGrid1.SelectedObject = e.Node.Tag;
    }
}