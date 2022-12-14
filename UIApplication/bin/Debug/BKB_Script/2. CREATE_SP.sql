USE [Florabank_online]
GO
/****** Object:  StoredProcedure [dbo].[wsp_parameter_select_api]    Script Date: 1/20/2021 11:51:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[wsp_parameter_select_api]
        
       @VtraceNo NUMERIC(16,0)
	   
--**Software** 
AS
BEGIN	
 SET NOCOUNT ON 
 select (case when isnull(org_trno,0)>0 then convert(char(16),org_trno) else '0' end) RefCode,
---Provided by PRAN Sample Value 5206
'5206' BankCode,a.curr_code ,a.Branch_code BranchCode,a.Accountno,a.traceno TrnNo,
isnull((select Depositor_code from cus_non_DPLN_trn_info where traceno=a.traceno),'0') DistributorCode,
(Case when a.dr_cr='CR' then a.amount_tk else 0 end) Credit,
(Case when a.dr_cr='DR' then a.amount_tk else 0 end) Debit,
isnull((select Bill_code from cus_non_DPLN_trn_info where traceno=a.traceno),'0') DepositSlip,
a.tdate TrnDate,
isnull(a.remark,'') Remarks
from daily_trn_deposit a
where a.traceno = @VtraceNo


END


--exec wsp_parameter_select_api '3503010024001510'

GO
/****** Object:  StoredProcedure [dbo].[wsp_parameter_update_trace_api]    Script Date: 1/20/2021 11:51:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[wsp_parameter_update_trace_api]
        
 @VtraceNo NUMERIC(16,0)
	   
--**Software** 
AS
BEGIN	
 SET NOCOUNT ON 
update cus_depositor_trn_traceno set conformYN='Y', Conform_sysdate = GETDATE() where traceno = @VtraceNo 

END


--exec wsp_parameter_select_api '3503010024001510'

GO
