using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DisbursementViewDTOConvert
/// </summary>
public class DisbursementViewDTOConvert
{
    public DisbursementViewDTOConvert()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<WCFDisbursementViewDTO> ChangevDTOListToWCFdvDTOList(List<DisbursementViewDTO> dvList)
    {

        List<WCFDisbursementViewDTO> wcfDVList = new List<WCFDisbursementViewDTO>();
        foreach (DisbursementViewDTO dvDTO in dvList)
        {
            WCFDisbursementViewDTO wcfDV = WCFDisbursementViewDTO.Make(dvDTO.Item_Code, dvDTO.Item_Description, dvDTO.requisition_No,
            dvDTO.QuantityToGiveOut, dvDTO.Employee_ID, dvDTO.Dept_ID, dvDTO.Dept_Name, dvDTO.Requested_Quantity,
            dvDTO.Actual_Quantity, dvDTO.Retrieval_Date, dvDTO.Retrieval_ID, dvDTO.Remarks);
            wcfDVList.Add(wcfDV);

        }
        return wcfDVList;
    }

}