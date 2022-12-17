const App = {
    data() {
        return {
            tableData: [],
        };
    },
    mounted() {
        this.getData();
    },
    computed: {

    },
    watch: {
        tableData: "getData"
    },
    methods: {
        getData() {
            const url = '/Home/SearchList';
            axios.get(url)
                .then((res) => {
                    this.tableData = res.data;
                })
                .catch((err) => {
                    console.log(err);
                });
        },
        getbyID(SId) {
            $('#SType').css('border-color', 'lightgrey');
            $('#SDisease').css('border-color', 'lightgrey');
            $.ajax({
                url: "/Home/SearchGetById/" + SId,
                typr: "GET",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    $('#SId').val(result.SId);
                    $('#SType').val(result.SType);
                    $('#SDisease').val(result.SDisease);
                    $('#SSymptom').val(result.SSymptom);
                    $('#myModal').modal('show');
                    $('#btnUpdate').show();
                    $('#btnAdd').hide();
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
            return false;
        },
        clearTextBox() {
            $('#SId').val("");
            $('#SType').val("");
            $('#SDisease').val("");
            $('#SSymptom').val("");
            $('#btnUpdate').hide();
            $('#btnAdd').show();
            $('#SType').css('border-color', 'lightgrey');
            $('#SDisease').css('border-color', 'lightgrey');
            $('#SearchDelete').css('border-color', 'lightgrey');
        },
        Delele(ID) {
            var ans = confirm("確認刪除?");
            if (ans) {
                $.ajax({
                    url: "/Home/SearchDelete/" + ID,
                    type: "POST",
                    contentType: "application/json;charset=UTF-8",
                    dataType: "json",
                    success: function (result) {
                        loadData();
                    },
                    error: function (errormessage) {
                        alert(errormessage.responseText);
                    }
                });
            }
        },
        Update() {
            var res = validate();
            if (res == false) {
                return false;
            }
            var optObj = {
                SId: $('#SId').val(),
                SType: $('#SType').val(),
                SDisease: $('#SDisease').val(),
                SSymptom: $('#SSymptom').val(),
            };
            $.ajax({
                url: "/Home/SearchUpdate",
                data: JSON.stringify(optObj),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    loadData();
                    $('#myModal').modal('hide');
                    $('#SId').val("");
                    $('#SType').val("");
                    $('#SDisease').val("");
                    $('#SSymptom').val("");
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
    },
};
const app = Vue.createApp(App);
app.use(ElementPlus);
app.mount("#app");