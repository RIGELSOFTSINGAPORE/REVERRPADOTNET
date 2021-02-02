<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Analysis_Servicecenter_popup.aspx.vb" Inherits="Ganges33.Analysis_Servicecenter_popup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h1>User Information</h1>
           <%-- <table border="1">
               
                              <tr>
                                    <th>Created date:</th>
                                  <th>Created user:</th>
                                     <th>Updated Date:</th>
                                    <th>Updated User:</th>
                                    <th>User Name:</th>
                                     <th>Password:</th>
                                    <th>Engineer ID:</th>
                                     <th>User Leve1:</th>
                                    <th>Branch Code1:</th>
                                    <th>Branch Code2:</th>
                                     <th>Branch Code3:</th>
                                    <th>Branch Code4:</th>
                                     <th>Branch Code5:</th>
                                     <th>Surname:</th>
                                    <th>Name:</th>
                                    <th>Middle Name:</th>
                                     <th>DOB:</th>
                                    <th>Sex:</th>
                                     <th>Superior:</th>
                                    <th>Address Line 1:</th>
                                     <th>Address Line 2:</th>
                                    <th>Address Line 3:</th>
                                    <th>Zip Code:</th>
                                     <th>Telephone No1:</th>
                                    <th>Mobile No:</th>
                                    <th>Email ID:</th>
                                     <th>Telephone No2:</th>
                                    <th>Delete flag:</th>
                                    <th>Admin Flag:</th>
                                     <th>Em Surname:</th>
                                     <th>Gua Name:</th>
                                    <th>Gua Telephone :</th>
                                     <th>Gua Address Line 1:</th>
                                    <th>Gua Address Line 2:</th>
                                     <th>Gua Zip Code:</th>
                                    <th>Gua Email ID:</th>
                                    <th>Hire Date:</th>
                                    <th>Dep Date:</th>
                                     <th>Class:</th>
                                    <th>Position:</th>
                                    <th>Work Location:</th>
                                    <th>Time:</th>
                                    <th>Higher Date1:</th>
                                    <th>Higher Date2:</th>
                                    <th>Higher Name:</th>
                                     <th>Uni date1:</th>
                                     <th>Uni date2:</th>
                                     <th>Uni name:</th>
                                    <th>Employee h1:</th>
                                      <th>Employee h2:</th>
                                    <th>Employee Name1:</th>
                                    <th>Employee H3:</th>
                                    <th>Employee H4:</th>
                                    <th>Employee Name2:</th>
                                    <th>QUA Name1:</th>
                                     <th>QUA Date1:</th>
                                     <th>QUA Name2:</th>
                                     <th>QUA Date2:</th>
                                     <th>QUA Name3:</th>
                                     <th>QUA Date3:</th>
                                     <th>Paid H1:</th>
                                    <th>Paid H2:</th>
                                     <th>Work Time:</th>
                                    
                                </tr>
                                <tr>
                                   <td>
                                        <asp:Label ID="lblCRTDT" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblCRTCD" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblUpddt" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblUPDCD" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblUseid" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                   
                                    <td>
                                        <asp:Label ID="lblPassword" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                     
                                    <td>
                                        <asp:Label ID="lblEngId" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblUserlvl" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblbranchcode1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblbranchcode2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblbranchcode3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblbranchcode4" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblbranchcode5" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                   
                                    <td>
                                        <asp:Label ID="lblSurname" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblMiddleName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                   
                                    <td>
                                        <asp:Label ID="lblDOB" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblSex" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblSuperior" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblAddressLine1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblAddressLine2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblAddressLine3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblZipCode" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblTelephoneNo1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblMobileNo" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblEmailID" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                   
                                    <td>
                                        <asp:Label ID="lblTelephoneNo2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblDeleteflag" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblAdminFlag" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblemSurname" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblGuaName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblgua_tel" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblGuaAddressLine1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblGuaAddressLine2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblGuaZipCode" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblGuaEmailID" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblHireDate" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblDepDate" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                   
                                    <td>
                                        <asp:Label ID="lblClass" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblPosition" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                              
                                    
                                    <td>
                                        <asp:Label ID="lblWorkLocation" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblTime" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblHigherDate1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblHigherDate2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblHigherName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblunidate1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblunidate2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lbluni_name" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                     
                                    <td>
                                        <asp:Label ID="lblEmployeeh1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                              
                                   
                                    <td>
                                        <asp:Label ID="lblEmployeeh2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblEmployeeName1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblEmployeeh3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblEmployeeH4" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblEmployeeName2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblQUAName1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblDate" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblQUAName2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblQUADate2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                     
                                    <td>
                                        <asp:Label ID="lblQUAName3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblQUADate3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblPaidH1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                
                                    
                                    <td>
                                        <asp:Label ID="lblPaidH2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                               
                                    
                                    <td>
                                        <asp:Label ID="lblWorkTime" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                            </table>--%>

            <table border="1">
               
                              <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Created Date:</td>
                                    <td>
                                        <asp:Label ID="lblCRTDT" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Created User:</td>
                                    <td>
                                        <asp:Label ID="lblCRTCD" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Updated Date:</td>
                                    <td>
                                        <asp:Label ID="lblUpddt" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Updated User:</td>
                                    <td>
                                        <asp:Label ID="lblUPDCD" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>


                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">User Name:</td>
                                    <td>
                                        <asp:Label ID="lblUseid" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Password:</td>
                                    <td>
                                        <asp:Label ID="lblPassword" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Engineer ID:</td>
                                    <td>
                                        <asp:Label ID="lblEngId" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">User Leve1:</td>
                                    <td>
                                        <asp:Label ID="lblUserlvl" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Branch Code1:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Branch Code2:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Branch Code3:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Branch Code4:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode4" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Branch Code5:</td>
                                    <td>
                                        <asp:Label ID="lblbranchcode5" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Surname:</td>
                                    <td>
                                        <asp:Label ID="lblSurname" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Name:</td>
                                    <td>
                                        <asp:Label ID="lblName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Middle Name:</td>
                                    <td>
                                        <asp:Label ID="lblMiddleName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">DOB:</td>
                                    <td>
                                        <asp:Label ID="lblDOB" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Sex:</td>
                                    <td>
                                        <asp:Label ID="lblSex" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Superior:</td>
                                    <td>
                                        <asp:Label ID="lblSuperior" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>


                              <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Address Line 1:</td>
                                    <td>
                                        <asp:Label ID="lblAddressLine1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Address Line 2:</td>
                                    <td>
                                        <asp:Label ID="lblAddressLine2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Address Line 3:</td>
                                    <td>
                                        <asp:Label ID="lblAddressLine3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Zip Code:</td>
                                    <td>
                                        <asp:Label ID="lblZipCode" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Telephone No1:</td>
                                    <td>
                                        <asp:Label ID="lblTelephoneNo1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Mobile No:</td>
                                    <td>
                                        <asp:Label ID="lblMobileNo" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Email ID:</td>
                                    <td>
                                        <asp:Label ID="lblEmailID" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Telephone No2:</td>
                                    <td>
                                        <asp:Label ID="lblTelephoneNo2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Delete flag:</td>
                                    <td>
                                        <asp:Label ID="lblDeleteflag" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Admin Flag:</td>
                                    <td>
                                        <asp:Label ID="lblAdminFlag" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>


                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Em Surname:</td>
                                    <td>
                                        <asp:Label ID="lblemSurname" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Gua Name:</td>
                                    <td>
                                        <asp:Label ID="lblGuaName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Gua Telephone :</td>
                                    <td>
                                        <asp:Label ID="lblgua_tel" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Gua Address Line 1:</td>
                                    <td>
                                        <asp:Label ID="lblGuaAddressLine1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Gua Address Line 2:</td>
                                    <td>
                                        <asp:Label ID="lblGuaAddressLine2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                              <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Gua Zip Code:</td>
                                    <td>
                                        <asp:Label ID="lblGuaZipCode" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Gua Email ID:</td>
                                    <td>
                                        <asp:Label ID="lblGuaEmailID" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Hire Date:</td>
                                    <td>
                                        <asp:Label ID="lblHireDate" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Dep Date:</td>
                                    <td>
                                        <asp:Label ID="lblDepDate" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Class:</td>
                                    <td>
                                        <asp:Label ID="lblClass" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Position:</td>
                                    <td>
                                        <asp:Label ID="lblPosition" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Work Location:</td>
                                    <td>
                                        <asp:Label ID="lblWorkLocation" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Time:</td>
                                    <td>
                                        <asp:Label ID="lblTime" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Higher Date1:</td>
                                    <td>
                                        <asp:Label ID="lblHigherDate1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Higher Date2:</td>
                                    <td>
                                        <asp:Label ID="lblHigherDate2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Higher Name:</td>
                                    <td>
                                        <asp:Label ID="lblHigherName" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Uni date1:</td>
                                    <td>
                                        <asp:Label ID="lblunidate1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Uni date2:</td>
                                    <td>
                                        <asp:Label ID="lblunidate2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Uni name:</td>
                                    <td>
                                        <asp:Label ID="lbluni_name" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Employee h1:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeh1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>



                              <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Employee h2:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeh2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Employee Name1:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeName1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Employee H3:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeh3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Employee H4:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeH4" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Employee Name2:</td>
                                    <td>
                                        <asp:Label ID="lblEmployeeName2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">QUA Name1:</td>
                                    <td>
                                        <asp:Label ID="lblQUAName1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">QUA Date1:</td>
                                    <td>
                                        <asp:Label ID="lblDate" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">QUA Name2:</td>
                                    <td>
                                        <asp:Label ID="lblQUAName2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">QUA Date2:</td>
                                    <td>
                                        <asp:Label ID="lblQUADate2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">QUA Name3:</td>
                                    <td>
                                        <asp:Label ID="lblQUAName3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                             <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">QUA Date3:</td>
                                    <td>
                                        <asp:Label ID="lblQUADate3" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>

                             <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Paid H1:</td>
                                    <td>
                                        <asp:Label ID="lblPaidH1" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Paid H2:</td>
                                    <td>
                                        <asp:Label ID="lblPaidH2" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                             <tr>
                                    <td style="font-weight:800; font-size:x-large" class="StrongText">Work Time:</td>
                                    <td>
                                        <asp:Label ID="lblWorkTime" runat="server" Style="text-align: center" Font-Bold="true" Font-Size="X-Large" CssClass="StrongText"></asp:Label></td>
                                </tr>
                            </table>




            <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript">
            $(function () {
                if (window.opener != null && !window.opener.closed) {
                    var rowIndex = window.location.href.split("?")[1].split("=")[1];
                    var parent = $(window.opener.document).contents();
                    var row = parent.find("[id*=GridSetupUser]").find("tr").eq(rowIndex);
                    $("#CRTDT").html(row.find("td").eq(0).html());
                    //$("#CRTCD").html(row.find("td").eq(1).html());
                    //$("#UPDDT").html(row.find("td").eq(2).html());
                    //$("#UPDCD").html(row.find("td").eq(3).html());
                    //$("#UPDPG").html(row.find("td").eq(4).html());
                    //$("#DELFG").html(row.find("td").eq(5).html());
                    //$("#ship_name").html(row.find("td").eq(6).html());
                    //$("#ship_info").html(row.find("td").eq(7).html());
                    //$("#ship_manager").html(row.find("td").eq(8).html());
                    //$("#ship_tel").html(row.find("td").eq(9).html());
                    //$("#ship_add1").html(row.find("td").eq(10).html());
                    //$("#ship_add2").html(row.find("td").eq(11).html());
                    //$("#ship_add3").html(row.find("td").eq(12).html());
                    //$("#zip").html(row.find("td").eq(13).html());
                    //$("#e_mail").html(row.find("td").eq(14).html());
                    //$("#ship_service").html(row.find("td").eq(15).html());
                    //$("#open_time").html(row.find("td").eq(16).html());
                    //$("#close_time").html(row.find("td").eq(17).html());
                    //$("#opening_date").html(row.find("td").eq(18).html());
                    //$("#closing_date").html(row.find("td").eq(19).html());
                    //$("#ship_code").html(row.find("td").eq(20).html());
                    //$("#ship_mark").html(row.find("td").eq(21).html());
                    //$("#item_1").html(row.find("td").eq(22).html());
                    //$("#item_2").html(row.find("td").eq(23).html());
                    //$("#mess_1").html(row.find("td").eq(24).html());
                    //$("#mess_2").html(row.find("td").eq(25).html());
                    //$("#mess_3").html(row.find("td").eq(26).html());
                    //$("#regi_deposit").html(row.find("td").eq(27).html());
                    //$("#PO_no").html(row.find("td").eq(28).html());
                    //$("#inspection1_start").html(row.find("td").eq(29).html());
                    //$("#inspection1_end").html(row.find("td").eq(30).html());
                    //$("#inspection2_start").html(row.find("td").eq(31).html());
                    //$("#inspection2_end").html(row.find("td").eq(32).html());
                    //$("#inspection3_start").html(row.find("td").eq(33).html());
                    //$("#inspection3_end").html(row.find("td").eq(34).html());
                    //$("#open_start").html(row.find("td").eq(35).html());
                    //$("#open_end").html(row.find("td").eq(36).html());
                    //$("#close_start").html(row.find("td").eq(37).html());
                    //$("#close_end").html(row.find("td").eq(38).html());
                    //$("#GSTIN").html(row.find("td").eq(39).html());
                    //$("#Parent_Ship_Name").html(row.find("td").eq(40).html());
                    //$("#IsChildShip").html(row.find("td").eq(41).html());
                    //$("#RpaClientUserId").html(row.find("td").eq(42).html());
                    //$("#RpaClientPwd").html(row.find("td").eq(43).html());
                    //$("#pwdupdateddate").html(row.find("td").eq(44).html());
                    //$("#IsShipCodeChanged").html(row.find("td").eq(45).html());
                }
            });
        </script>
        </div>
    </form>
</body>
</html>
