$(document).ready(function () {
    menu = new menuJS();
    
})
var mode = true;
class menuJS{
    constructor(){
        var me =this;
        this.initEvent();
        }
    initEvent(){
        $('#user-ava').click(this.showUserMenu);
        $('body').click(this.hideUserMenu);
    }


    showUserMenu(){
       $('.menu-user').addClass("show-dio");
    }

    hideUserMenu(){
       var me = this;
    if(!$(event.target).is('img')){
            $('.menu-user').removeClass("show-dio");
        }
       
    }
}