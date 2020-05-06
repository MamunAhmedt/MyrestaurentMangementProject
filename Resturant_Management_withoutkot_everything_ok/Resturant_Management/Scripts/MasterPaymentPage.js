var Funds=[];
function ChangeSaveButtonValue(name) {
    $(".savebutton").attr('value',name);
    $('.savebutton').attr('id', name);
    $('.savebutton').attr('onclick', name+"()");
    

}

function RedirecttoConcernMethod(Methodname) {
    Methodname();
}


function NavbarAdd(button) {
    $('#FirstColumnContent').empty();

    $('<h5/>', {
        html: 'Name :',
        class: 'form-group'


}).appendTo('#FirstColumnContent');


    $('<input/>', {
        type: "text",
        id: 'notification',
        style: 'margin-top: 10%',
        class:'form-group'

    }).appendTo('#FirstColumnContent');

    $('<span/>',
        {
            html: "Please Enter Method Name",
            id: 'Error',
            style: 'visibility:Hidden',
            class: 'form-group merror'
        }).appendTo('#FirstColumnContent');

    ChangeSaveButtonValue(button.value);
    

}


function Remove(button) {
    ChangeSaveButtonValue(button.value);

    $('#FirstColumnContent').empty();


    $('<h5/>', {
        html: 'Name :',
        style: 'margin-top: 12%'


    }).appendTo('#FirstColumnContent');

    $('<input/>', {
        type: "text",
        id: 'notification',
        style: 'margin-top: 12%',
        onkeyup: 'findelement()'

    }).appendTo('#FirstColumnContent');


    $('<span/>',
        {
            html: "Please Enter Method Name",
            id: 'Error',
            style: 'visibility:Hidden',
            class: 'form-group merror'
        }).appendTo('#FirstColumnContent');

    ChangeSaveButtonValue(button.value);
}

function findelement() {
    var Name = $('#notification').val();

    if (Name === "") {
        $('.merror').css('visibility', 'visible');
    }
    else {
        
    
    $.ajax({
        type: 'POST',
        url: '/PaymentMode/Findelementanddelete',
        data: {
            'name': Name
        },
        success: function (data) {
            if (data == "true") {
                alert("succesfully removed " + Name + "As Payment Method");
                $('#notification').val("");
                
            }
            
            

        }

    });
}
}

function Update(button) {
    ChangeSaveButtonValue(button.value);
}

function Add() {
    var Name = $('#notification').val();

    if (Name === "") {
        $('.merror').css('visibility', 'visible');
    }
    
    else {
         $.ajax({
            type: "GET",
            url: '/PaymentMode/CheckMethodExistanceInDatabase',
            data: { 'Name': Name },
            success:function(data) {
                if (data==="true") {
                    alert("This payment Method is already in the database");
                    $('#notification').val("");


                }

                else {
                    var paymentmode = {
                        PaymentMode: Name
                    }
                    var total = {
                        FundName: Name,
                        Amount: 0
                }

                    $.ajax({
                        type: 'post',
                        url: '/PaymentMode/Save',
                        data: paymentmode
                        

                    });

                    $.ajax({
                        type: 'post',
                        url: '/PaymentMode/SaveFunds',
                        data: total



                    });

                    alert("New Payment Method Added Successfully");
                    $('#notification').val("");

                }
            }
        });


      
    }

   
  
}

function loadamounts() {

     $.ajax({

        type: 'GET',
        url: '/PaymentMode/getsumofEachPaymentMode',
        success: function (data) {
            Funds = data;
            $('#CashAmount,#CardAmount,#RocketAmount,#BkashAmount').val(0);
            $('#CashAmount').val(data.Cash);
            $('#CardAmount').val(data.Card);
            $('#BkashAmount').val(data.Bkash);
            $('#RocketAmount').val(data.Rocket);

            
        }

    });
  

    
}


function CheckFromFunds(parameters) {

    var name = $('#TransferFrom option:selected').text();

    var value = parseInt($('#' + name + 'Amount').val());
    var TransferAmount = parseInt($('#AmountBox').val());

    if (value && TransferAmount<value)
    {
       return true;
    }
   else
   {
       return false;
   }

}






$(document).ready(function () {

    loadamounts();

   

    $('#TransferFund').click(function () {
        
        var isallvalid = true;

        if ($('#AmountBox').val() >0) {


            if (!($('#AmountBox').val().trim() != '' && (parseInt($('#AmountBox').val()) || 0))) {

                isallvalid = false;
                $('#AmountBox').siblings('span.Error').css('visibility', 'visible');

            } else {
                $('#AmountBox').siblings('span.Error').css('visibility', 'hidden');


            }
            if ($('#TransferFrom option:selected').text() === $('#TransferTo option:selected').text()) {
                isallvalid = false;
                alert("BOTH THE PAYMENT MODES CAN'T BE SAME");
            }
            if (!CheckFromFunds()) {
                isallvalid = false;
                alert("AMOUNT VALUE CAN'T BE GREATER THAN FUNDS");
            }
        }
        else {
            isallvalid = false;
            $('#AmountBox').siblings('span.Error').css('visibility', 'visible');
        }

        //if (!CheckFromFunds()) {
        //    isallvalid = false;
        //    alert("AMOUNT VALUE CAN'T BE GREATER THAN FUNDS");
        //}


        //if ($('#TransferFrom option:selected').text()===$('#TransferTo option:selected').text()) {
        //    isallvalid = false;
        //    alert("BOTH THE PAYMENT MODES CAN'T BE SAME");
        //}

        if (isallvalid) {
            $.ajax({
                type: 'POST',
                url: '/PaymentMode/Transferfunds',
                data: {
                    'From': $('#TransferFrom option:selected').text(), 
                    'To': $('#TransferTo option:selected').text(),
                    'Amount': parseInt($('#AmountBox').val())
                },
                success:function(data) {
                    if (data) {
                        alert("Success");
                        $('#AmountBox').val('');
                        $('#TransferFrom option:selected').val('0');
                    }
                }
            });
        }


    });


});


