const App = {
    data() {
        return {
            tableData: [],
            eledate: '',
            userID:'',
        };
    },
    mounted() {
        this.getData();
    },
    computed: {

    },
    watch: {
        tableData: "getData",
    },
    methods: {
        tableRowClassName({ row, rowIndex }) {
            if (rowIndex === 1) {
                return 'warning-row';
            } else if (rowIndex === 3) {
                return 'success-row';
            }
            return '';
        },
        getData() {
            const url = '/Return/GetByMId/';
            const MId = this.$refs.userID.innerHTML;
            axios.get((url), {
                params: {
                    ID: MId
                }
            })
                .then((res) => {
                    this.tableData = res.data;
                })
                .catch((err) => {
                    console.log(err);
                });
        },
        clearTextBox() {
            $('#RId').val("");
            $('#RType').val("");
            $('#RHospital').val("");
            $('#RDate').val("");
            $('#btnUpdate').hide();
            $('#btnAdd').show();
        },
        getbyID(RId) {
            $('#RType').css('border-color', 'lightgrey');
            $('#RHospital').css('border-color', 'lightgrey');
            $.ajax({
                url: "/Return/GetById/" + RId,
                typr: "GET",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    $('#RId').val(result.RId);
                    $('#MId').val(result.MId);
                    $('#RType').val(result.RType);
                    $('#RHospital').val(result.RHospital);
                    $('#RDate').val(result.RDate);
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
        Delele(ID) {
            var ans = confirm("確認刪除?");
            if (ans) {
                $.ajax({
                    url: "/Return/Delete/" + ID,
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
    },
};
const app = Vue.createApp(App);
app.use(ElementPlus);
app.mount("#app");