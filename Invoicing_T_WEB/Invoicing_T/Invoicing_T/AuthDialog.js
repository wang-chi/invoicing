//無權限到訪
function NonAuth(){
    $('#AuthModal').on('show.bs.modal ', function (e) {
        alert('Hi');
    })
}