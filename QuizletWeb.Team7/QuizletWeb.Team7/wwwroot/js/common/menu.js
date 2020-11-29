$(document).ready(function () {
    menu = new menuJS();
    
})
var mode = true;
class menuJS{
    constructor(){
        this.initEvent();
        }
    initEvent(){
        $('#user-ava').on('click',mode,this.showUserMenu);
    }
    showUserMenu(){
        if(mode){
            $('.menu-user').hide();
            mode=false;
        }else if(mode = false)
        $('.menu-user').hide();
        mode=true;
    }
    
}