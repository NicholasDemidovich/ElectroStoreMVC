var modal = document.getElementById("myModal");

var btn = document.getElementsByName("myBtn");

var span = document.getElementsByClassName("close")[0];

var Id;

btn.forEach(element => {
    element.onclick = function () {
        modal.style.display = "block";
        document.getElementById("permDelete").setAttribute('id', 'permDelete' + element.id);
        document.getElementById("tempDelete").setAttribute('id', 'tempDelete' + element.id);

        document.getElementById("permDelete" + element.id).setAttribute('href', "/Admin/ProductDeletePerm?id=" + element.id);
        document.getElementById("tempDelete" + element.id).setAttribute('href', "/Admin/ProductDeleteTemp?id=" + element.id);
        Id = element.id;
    }
});

span.onclick = function () {
    modal.style.display = "none";
    document.getElementById("permDelete" + Id).setAttribute('id', 'permDelete');
    document.getElementById("tempDelete" + Id).setAttribute('id', 'tempDelete');
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
        document.getElementById("permDelete" + Id).setAttribute('id', 'permDelete');
        document.getElementById("tempDelete" + Id).setAttribute('id', 'tempDelete');
    }
}