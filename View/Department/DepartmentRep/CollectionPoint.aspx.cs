using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SA45Team02_SSIS;

public partial class Department_DepartmentRep_Default : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadPage();
        }
    }

    public void LoadPage()
    {
        //Read from login user's dept (currently set to "COMM")
        Department dept = CollectionPointController.RetrieveDeptByDepID("COMM");
        CollectionPoint current = CollectionPointController.RetrieveCollectPointByID(dept.CollectionPoint_ID);
        lbCollectPt.Text = current.Description;

        rbCollectionPt.DataSource = CollectionPointController.RetrieveCollectionPointtList();
        rbCollectionPt.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Department dept = CollectionPointController.RetrieveDeptByDepID("COMM");
        CollectionPoint collect = CollectionPointController.RetrieveCollectionPointByDescription(rbCollectionPt.SelectedValue);

        CollectionPointController.UpdateCollectionPoint(dept, collect);

        LoadPage();

        lbStatus.Text = "Collection point updated successsfully.";
    }
}