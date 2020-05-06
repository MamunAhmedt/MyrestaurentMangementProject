/// <reference path="MasterPaymentPage.js" />
var products = [];
var li = [];
var ServiceMan = [];
var Tables = [];
var RemoveItemTotal = 0;
var GrandTotal = 0;
var TodaysDate;
var paymenthods = [];
var pendingcheck;
var localstoragekeys = [];

function GetFormatedDate() {

    var fullDate = new Date();
    var twoDigitMonth = fullDate.getMonth() + 1 + ""; if (twoDigitMonth.length == 1) twoDigitMonth = "0" + twoDigitMonth;
    var twoDigitDate = fullDate.getDate() + ""; if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;
    TodaysDate = twoDigitMonth + "/" + twoDigitDate + "/" + fullDate.getFullYear() + "/";


}

function Print(){

    $('#Table').html($('#TableNo option:selected').val().trim());
    $('#Server').html($('#ServiceBoy option:selected').val().trim());
    $('#kotpage').print();


}

function SaveNotification() {
    var Notificationstring = $('#NotificationString').val();
    var Showingdate = new Date($('#DatePicker').val())

    var status = true;


    var day = (Showingdate.getDate());
    var month = (Showingdate.getMonth() + 1);

    var year = (Showingdate.getFullYear());

    if (Notificationstring == "") {
        $('#StringError').css('visibility', 'visible');
        status = false;
    }
    else {

        $('#StringError').css('visibility', 'hidden');
    }

    if (day.toString() == "NaN" ||month.toString() == "NaN"|| year.toString() == "NaN") {
        $('#DateError').css('visibility', 'visible').html("Please select Valid Date");
        status = false;

    }
   
   else {

       $('#DateError').css('visibility', 'hidden');

   }

    
        

        

   

    
   

       
      

        

        if (day.toString().length == 1) {
            day = "0" + day;
        }
        if (month.toString().length == 1) {
            month = "0" + month;
        }

        // alert(day.toString().length);
        Showingdate = month + "/" + day + "/" + year + "/";
        if (status) {

            $.ajax({

                type: "Get",
                url: '/Notification/SaveNotification',
                data: { 'Notification': Notificationstring, 'Date': Showingdate },
                success: function () {
                    $('#NotificationString').val("");
                    $('#DatePicker').val("");


                },




            })
        }
    }



function LoadProducts(element) {
    
    if (products.length == 0) {
     
        $.ajax({

            type: "GET",
            url: '/Bills/GetProducts',
            success: function (data) {

                products = data;

                renderproducts(element);
            }

        }
            );
        
    }
    else {
        renderproducts(element);

    }
}



function renderproducts(element)
{
    $ele = $(element);
    $ele.empty();


    $ele.append($('<option/>').val('0').text('Select Product'));
    
    $.each(products, function (i, val) {

        $ele.append($('<option/>').val(val.ItemId).text(val.ItemName));
       

    });



}

function LoadUnitPrice(categoryDD) {
    $("#Quantity,#UnitPrice,#DiscountRate,#Total").val('0');



    $.ajax({
        type: "GET",
        url: "/Bills/GetProductUnitPrice",
        data: { 'id': ($(categoryDD).val())},
        success: function (data) {
           // $('#UnitPrice').val(data);
            //render products to appropriate dropdown
            RenderUnitPrice($('#UnitPrice'), data.ItemUnitPrice);
            $('#DiscountRate').val(data.DiscountRateOnUnitPrice.DiscountOnUnitPrice)
           
        },
        error: function (error) {
            console.log(error);
        }
    });
}


function rendertable() {

    var Total=0;
    var OrderCount=0;
    if (li.length <= 0) {
        $('#SearchResult tbody tr ').remove();
        $('#OrderCount').val(0);
        $('#Total').val(0);
        $('#Result span.error').css('visibility', 'visible');

    }
    else {
        $('#SearchResult tbody tr ').remove();
        $('#Result span.error').css('visibility', 'hidden');
        $.each(li, function (i, val) {
           

            
            var productItem = '<tr><td>' + val.RecieptId + '</td><td class="pc">' + val.RecieptNo + '</td><td class="Quantity">' + val.ServiceBoyid + '</td><td class="DiscountRate">'
                + val.TableNo + '</td><td class="Rate">' + val.NetAmount + '</td><td class="TotalPrice">' + val.TimeDate + '</td></tr>';
            Total = val.NetAmount + Total;
             OrderCount = i;

            $('#SearchResult tbody').append(productItem);


        });
        $('#OrderCount').val(OrderCount + 1);
        $('#Total').val(Total);

    }
   


}


function GetSalesReport() {


  
    var date = new Date($('#DateFrom').val());
    day = (date.getDate());
    month = (date.getMonth() + 1);
    
    year = (date.getFullYear());

    if (day.toString().length == 1) {
        day = "0" + day;
    }
    if (month.toString().length == 1) {
        month = "0" + month;
    }

    // alert(day.toString().length);
    var DateFrom = month + "/" + day + "/" + year + "/";




    var date = new Date($('#DateTo').val());
    day =date.getDate();
    month = date.getMonth() + 1;
    year = date.getFullYear();


    if (day.toString().length == 1) {
        day = "0" + day;
    }
    if (month.toString().length == 1) {
        month = "0" + month;
    }
    
   // alert(day.toString().length);
    var DateTo =  month + "/" + day + "/" + year + "/";
       

   
    
 
 

        $.ajax({

            type: "GET",
            url: "/RecieptAccount/GetDailySales",
            data: {
                'Datefrom': DateFrom,
                'Dateto': DateTo
            },
            success: function (data) {
                li = data;
                rendertable();

            }






        });
    
}









function RenderUnitPrice(element, data) {
    //render product
    
    element.val(data)
 
   
}

function LoadServiceboy(element) {
    if (ServiceMan.length == 0) {

        $.ajax({

            type: "GET",
            url: '/Bills/GetServiceBoy',
            success: function (data) {

                products = data;

                RenderServiceBoy(element);
            }

        }
            );

    }
    else {
        RenderServiceBoy(element);

    }

}


function RenderServiceBoy(element){

    $ele = $(element);
    $ele.empty();


    $ele.append($('<option/>').val('0').text('Select ServiceBoy'));

    $.each(products, function (i, val) {

        $ele.append($('<option/>').val(val.ServiceManId).text(val.ServiceManName));


    });
}


function LoadTableNo(element) {

    if (Tables.length == 0) {

        $.ajax({

            type: "GET",
            url: '/Bills/GetTable',
            success: function (data) {

                products = data;

                RenderTable(element);
            }

        }
            );

    }
    else {
        RenderTable(element);

    }

}

function RenderTable(element) {

    $ele = $(element);
    $ele.empty();


    $ele.append($('<option/>').val('0').text('Select Table'));

    $.each(products, function (i, val) {

        $ele.append($('<option/>').val(val.TableId).text(val.TableNo));


    });

}



function CalCulateTotal(value) {

    // alert();

    var Total = $('#UnitPrice').val() * ($('#Quantity').val())
   
    var Discountrate = ($('#DiscountRate').val() / 100)
   
    var TotalafterDiscount = Total - (Total * Discountrate)


  $('#Total').val(TotalafterDiscount)
     
   // alert('Abc');

}



function loadpaymentmethods() {

    if (paymenthods.length === 0) {

        $.ajax({

            type: "GET",
            url: '/Bills/GetPayMethods',
            success: function (data) {

                paymenthods = data;

                renderpaymentmethods();
            }

        }
        );

    }
    else {
        renderpaymentmethods();

    }
}



function renderpaymentmethods() {
    $RecieptPagePaymentSelect = $('#PaymentMode');
    $MasterPaymentSelect_From = $('#TransferFrom');
    $MasterPaymentSelect_To = $('#TransferTo');


    $RecieptPagePaymentSelect.empty();
    $MasterPaymentSelect_From.empty();
    $MasterPaymentSelect_To.empty();


    //$ele.append($('<option/>').val('0').text('Select Product'));

    $.each(paymenthods, function (i, val) {

        $RecieptPagePaymentSelect.append($('<option/>').val(val.id).text(val.PaymentMode));
        $MasterPaymentSelect_From.append($('<option/>').val(val.id).text(val.PaymentMode));
        $MasterPaymentSelect_To.append($('<option/>').val(val.id).text(val.PaymentMode));



    });



}


function NewBillId() {

    $.ajax({
        type:'GET',
        url: '/Bills/BillIdGenerator',
        success: function (data) {
            if (localStorage.getItem(data) == null) {
                $('#OrderNo').val(data);
            }
          
            var billId = parseInt($('#OrderNo').val());
            $('#OrderNo').val(billId+1);

        }


    });


}

function saveholdingtablereciepttodb(RecieptNo) {

    $.ajax({
        type: 'POST',
        url: '/HoldingTable/SaveHoldingTableReciept',
        data:{'RecieptNo':RecieptNo},
        success: function () {

            alert("saved")
            loadholdingtables();

        }


    });

}

function loadholdingtables() {
    var holdingitems =[];

    $.ajax({

        type: 'Get',
        url: '/HoldingTable/GetAllHoldingTableReciept',
        success: function (data) {
            holdingitems = data;
            $('#HoldingItems td').remove();
            $.each(holdingitems, function (i, val) {
                var Pendingtable = "<td> <input type='button'  value=" + val.holdingReciept + "  onclick=" + "GetThisElemntFromLocalStorage(" + val.holdingReciept + ") /></td>"
                $('#HoldingItems').append(Pendingtable);


            });
        }

    });

   
}




$(document).ready(function () {
    loadholdingtables();
    loadpaymentmethods();
    LoadProducts('#product ');
    LoadServiceboy('#ServiceBoy');
    LoadTableNo('#TableNo');
   
    if (localStorage.length > 0) {

        for (var i = 0; i < localStorage.length; i++) {
            localstoragekeys = localStorage.key[i];
        }
    }


    $('#Printkot').click(function () {

        var wme = window.open("", "", "width = 100 height = 100");
        var value = document.getElementById("kotpage");
        wme.document.write(value.outerHTML);
        wme.document.close();
        wme.focus();
        wme.print();
        //wme.close();

    })



    $('#Add').click(function () {
        
        //validation and add order items
        var isAllValid = true;
        if ($('#product').val() == "0") {
            isAllValid = false;
            $('#product').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#product').siblings('span.error').css('visibility', 'hidden');
        }



        if ($('#ServiceBoy').val() == "0") {
            isAllValid = false;
            $('#ServiceBoy').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#ServiceBoy').siblings('span.error').css('visibility', 'hidden');
        }


        if ($('#TableNo').val() == "0") {
            isAllValid = false;
            $('#TableNo').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#TableNo').siblings('span.error').css('visibility', 'hidden');
        }



       

        if (!($('#Quantity').val().trim() != '' && (parseInt($('#Quantity').val()) || 0))) {
            isAllValid = false;
            $('#Quantity').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Quantity').siblings('span.error').css('visibility', 'hidden');
        }

     

        if (isAllValid) {
           
           
                ProductId = parseInt($('#product option:selected').val()),
                ProductName = $('#product option:selected').text(),
                Quantity = parseInt($('#Quantity').val()),
                DiscountRate = parseInt($('#DiscountRate').val()),
                UnitPrice = parseInt($('#UnitPrice').val()),
                Total = parseInt($('#Total').val()),
                GrandTotal = GrandTotal + Total;
          
             

            var productItem ='<tr> <td class="ProductId">'+ProductId+'</td><td class="pc">'+ ProductName + '</td><td class="Quantity">' + Quantity + '</td><td class="DiscountRate">' + DiscountRate + '</td><td class="Rate">' + UnitPrice + '</td><td class="TotalPrice">' + Total+ '</td><td>' + '<input type="button" value="Remove" class="remove btn-danger form-control"/>'+ '</td></tr>';
            $('#orderdetailsItems tbody').append(productItem);

           
            $('#TotalAmount').val(GrandTotal);
            $('#product').val('0');
            $('#Quantity,#UnitPrice,#DiscountRate,#Total').val('');
            $('#orderItemError').empty();

        }
    })
           
            $('#orderdetailsItems').on('click', '.remove', function () {
                RemoveItemTotal = parseInt($(this).closest("tr").find('td:eq(5)').text());
                GrandTotal=(GrandTotal-RemoveItemTotal);
                RemoveItemTotal=0;
                $(this).parents('tr').remove();
                $('#TotalAmount').val(GrandTotal);

            });
           
            
        
           
           
            $('#NewOrder').click(function () {
                
                var list = [];
                var tbody=$('#orderdetailsItems tbody');
               if(tbody.children().length==0) {
                     
                        alert("Nothing To save Please Add Some Items to The Cart Please");

                    }
               else {
                   $('#orderdetailsItems tbody tr').each(function(index, ele){

                        var orderItem = {
                            ProductId: parseInt($('.ProductId', this).text()),
                            ProductName: $('.pc', this).text(),
                            Quantity: parseInt($('.Quantity', this).text()),
                            DiscountRate: parseFloat($('.DiscountRate', this).text()),
                            UnitPrice : parseInt($('.Rate',this).text()),
                            Total : parseInt($('.TotalPrice',this).text())
                        }
                        list.push(orderItem);
                        })
                        var data = {
                            RecieptNo: $('#OrderNo').val().trim(),
                            TimeDate: $('#OrderDate').val().trim(),
                            ServiceBoyid: $('#ServiceBoy option:selected').val().trim(),
                            TableNo: $('#TableNo option:selected').val().trim(),
                            NetAmount: parseFloat($('#TotalAmount').val()),
                            OrderedItems: list,
                            PaymentMode: $('#PaymentMode option:selected').text(),
                        }
                       

                        let Order_Serialized = JSON.stringify(data);
                        localStorage.setItem(data.RecieptNo, Order_Serialized);
                   
                        
                        GrandTotal = 0;
                        $('#ServiceBoy,#TableNo,#TotalAmount').val('0');
                        $('#orderdetailsItems tbody tr').remove();
                        $('#Submit').attr('Value', 'Save Order');
                        NewBillId();
                        saveholdingtablereciepttodb($('#OrderNo').val().trim());
                        
                        //loadholdingtables();

                      


                    }




                

                       
              

            });


            $('#Submit').click(function () 
            {



                var isAllValid = true;

                //validate order items
                $('#orderItemError').text('');
                var list = [];
                var errorItemCount = 0;

                $('#orderdetailsItems tbody tr').each(function(index, ele) {
                    if (
                           parseInt ($('.ProductId', this).text()) == 0||
                            parseInt($('.Quantity', this).text()) == 0 
                    
                        )



                    {
                        errorItemCount++;
                        $(this).addClass('error');
                        alert("error");

                    }
                    else {
                 
                        var orderItem = {
                            ProductId: parseInt($('.ProductId', this).text()),
                            ProductName: $('.pc', this).text(),
                            Quantity: parseInt($('.Quantity', this).text()),
                            DiscountRate: parseFloat($('.DiscountRate', this).text())
                        }
                        list.push(orderItem);


                    }
            
            
        
        
                }

                        )//functionends


                if (errorItemCount > 0) {
                    $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
                    isAllValid = false;
                }
                if (list.length == 0) {
                    $('#orderItemError').text('At least 1 order item required.');
                    isAllValid = false;
                }

                if (isAllValid) {
                    var data = {
                        RecieptNo: $('#OrderNo').val().trim(),
                        TimeDate: $('#OrderDate').val().trim(),
                        ServiceBoyid: $('#ServiceBoy option:selected').val().trim(),
                        TableNo: $('#TableNo option:selected').val().trim(),
                        NetAmount: parseFloat($('#TotalAmount').val()),
                        OrderedItems: list,
                        PaymentMode: $('#PaymentMode option:selected').text(),
                    }
                        
               
                    $(this).val('Please wait...');

            $.ajax({
                type: 'POST',
                url: '/Bills/save',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert('Successfully saved');
                        //here we will clear the form
                        GrandTotal = 0;
                        $('#ServiceBoy,#TableNo,#TotalAmount').val('0');
                        $('#orderdetailsItems tbody tr').remove();
                        $('#Submit').attr('Value', 'Save Order');
                        NewBillId();

                        $.ajax({

                        });
                       
                    }
                    else {
                        alert('Error');
                    }

                    
                },
                error: function (error) {
                    console.log(error);
                    $('#Submit').text('Save');
                }
            });
        }





            })

           


    
    });


