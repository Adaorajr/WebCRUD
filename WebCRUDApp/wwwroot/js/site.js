function deleteItem(form) {
    if(confirm("Deseja realmente Excluir este Registro?")){
    $(form).parents('li').remove();
    }
}
