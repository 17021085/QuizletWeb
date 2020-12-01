$(document).ready(function () {
    home = new homeJS();
    
})
class homeJS{
    constructor(){
    var me = this;
        me.loadData()
    //   me.initEvent();
    }
   loadData(){
    $.ajax({
        url: "/api/FlashCards",
        method: "GET",
        data: {},
        dataType: "json",
        contentType: "application/json",
    }).done(function (response) {
        if (response) {
            $.each(response, function (index, item) {

                var EmployeeIndex = $(`<div>
                     
                     <p align="left">`+ item['flashcardtitle'] + `</p>
                     <p align="left">`+ item['descriptioncard'] + `</p>
                  
                         </div>`);
                         $('.main').append(EmployeeIndex);
              
            });
            
        }
    }).fail(function (response) {
        alert("fail");
    });   }
    
}