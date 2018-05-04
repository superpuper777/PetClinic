$(function () {

    var MyDateField = function (config) {
        jsGrid.Field.call(this, config);
    };

    var MyTimeField = function (config) {
        jsGrid.Field.call(this, config);
    };

    function valueToDate(value) {
        var date;
        if (value.indexOf('Date(') !== -1) {
            date = new Date(parseInt(value.replace('/Date(', '').replace(')/', '')));
        } else {
            date = new Date(value);
        }
        return date;
    }

    MyDateField.prototype = new jsGrid.Field({

        css: "date-field",            // redefine general property 'css'
        align: "center",              // redefine general property 'align'

        myCustomProperty: "foo",      // custom property

        sorter: function (date1, date2) {
            return new Date(date1) - new Date(date2);
        },

        itemTemplate: function (value) {
            return moment(valueToDate(value)).format("DD.MM.YYYY");
        },

        insertTemplate: function (value) {
            var $input = $("<input>");
            $input.on('keydown', function (e) {
                e.preventDefault();
            });
            return this._insertPicker = $input.datepicker({ defaultDate: new Date() });
        },

        editTemplate: function (value) {
            var $input = $("<input>");
            $input.on('keydown', function (e) {
                e.preventDefault();
            });
            return this._editPicker = $input.datepicker().datepicker("setDate", valueToDate(value));
        },

        insertValue: function () {
            var date = this._insertPicker.datepicker("getDate");
            return date ? date.toISOString() : undefined;
        },

        editValue: function () {
            var date = this._editPicker.datepicker("getDate");
            return date ? date.toISOString() : undefined;
        }
    });

    jsGrid.fields.date = MyDateField;


    MyTimeField.prototype = new jsGrid.Field({

        css: "time-field",            // redefine general property 'css'
        align: "center",              // redefine general property 'align'

        myCustomProperty: "foo",      // custom property

        //sorter: function (time1, time2) {
        //    return new Date(date1) - new Date(date2);
        //},

        itemTemplate: function (value) {
            return value;
        },

        insertTemplate: function (value) {
            var $input = $("<input>");
            $input.on('keydown', function (e) {
                e.preventDefault();
            });
            //$input.attr('readonly', true);
            return this._insertPicker = $input.datetimepicker({ format: 'H:i', lang: 'ru', allowTimes: window.GlobalAllowTimes, datepicker: false });
        },

        editTemplate: function (value) {
            var $input = $("<input>");
            $input.on('keydown', function (e) {
                e.preventDefault();
            });
            //$input.attr('readonly', true);
            $input.val(value);
            return this._editPicker = $input.datetimepicker({ format: 'H:i', lang: 'ru', allowTimes: window.GlobalAllowTimes, datepicker: false }); //.datepicker("setDate", valueToDate(value));
        },

        insertValue: function () {
            var time = this._insertPicker.val();
            return time;
        },

        editValue: function () {
            var time = this._editPicker.val();
            return time;
        }
    });

    jsGrid.fields.time = MyTimeField;

})