$(document).ready(function () {
    $(".facilities_area  .tab:first").addClass("active");
    $(".facilities_area  .tab").click(function (event) {
        index = $(this).index();
        console.log(index);
        $(".facilities_area  .tab").removeClass("active");
        $(this).addClass("active");
        jQuery(".facilities_area  .img").removeClass("top bottom center");
        var img1 = ".facilities_area  .img:nth-child(1)";
        var img2 = ".facilities_area  .img:nth-child(2)";
        var img3 = ".facilities_area  .img:nth-child(3)";
        if (index == 0) {
            $(img1).addClass("center");
            $(img2).addClass("top");
            $(img3).addClass("bottom");
        } else if (index == 1) {
            $(img1).addClass("bottom");
            $(img2).addClass("center");
            $(img3).addClass("top");
        } else {
            $(img1).addClass("top");
            $(img2).addClass("bottom");
            $(img3).addClass("center");
        }
    });
    //  Invoice Pop up
    $(document).on(
        "click",
        ".lightbox-opened-mask .close",
        function () {
            $("html").removeClass("no-scroll");
            $("body").find(".lightbox-opened-mask ,.lightbox-opened").remove();
        }
    );
    $('#roomsadds').on('click', function () {
        value = $('.rooms-incdec').val();
        $('.rooms-incdec').val(++value);

        if (value > 0) {
            $('#roomssubs').removeAttr('disabled');
        }
    });
    $('#roomssubs').on('click', function () {
        value = $('.rooms-incdec').val();
        $('.rooms-incdec').val(--value);

        if (value <= 0) {
            $('#roomssubs').attr('disabled', 'disabled');
        }
    });

    //   child

    $('#addschild').on('click', function () {
        value = $('.child-incdec').val();
        $('.child-incdec').val(++value);

        if (value > 0) {
            $('#subschild').removeAttr('disabled');
        }
    });
    $('#subschild').on('click', function () {
        value = $('.child-incdec').val();
        $('.child-incdec').val(--value);

        if (value <= 0) {
            $('#subschild').attr('disabled', 'disabled');
        }
    });


    //   adults

    $('#addsadults').on('click', function () {
        value = $('.adults-incdec').val();

        $('.adults-incdec').val(++value);

        if (value > 0) {
            $('#subsadults').removeAttr('disabled');
        }
    });
    $('#subsadults').on('click', function () {
        value = $('.adults-incdec').val();
        $('.adults-incdec').val(--value);

        if (value <= 0) {
            $('#subsadults').attr('disabled', 'disabled');
        }
    });

    // booking -form validation
    $("#booking-frm").validate(
        {
            rules:
            {
                name: {
                    required: true,
                    charsonly: true
                },
                email: {
                    required: true,
                    email: true
                },
                contactno: {
                    required: true,
                    phoneUS: true
                },
                arrivaldate: {
                    required: true
                },
                departuredate: {
                    required: true
                },
                roomtype: {
                    required: true
                }
            },
            messages: {
                name: {
                    required: "Name field  is required.",
                },
                email: {
                    required: "email field  is required.",
                    email: "please enter the valid email"
                },
                contactno: {
                    required: "phone no field  is required.",
                },
                arrivaldate: {
                    required: "Arrival date is required."
                },
                departuredate: {
                    required: "Departure date is required."
                },
                roomtype: {
                    required: "Room Type is required."
                }
            },
            submitHandler: function (form) {
                form.submit();
                window.location.href = "thankmsg.html";
            }
        }
    );
    jQuery.validator.addMethod("charsonly", function (value) {
        return /^[a-z]+$/i.test(value);
    }, "please enter characters only");
    jQuery.validator.addMethod("phoneUS", function (phone_number, element) {
        phone_number = phone_number.replace(/\s+/g, "");
        return this.optional(element) || phone_number.length > 9 && phone_number.match(/^(\+?1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$/);
    }, "Please specify a valid phone number");



    // contact form validation
    $("#contact-frm").validate(
        {
            rules:
            {
                firstname: {
                    required: true,
                    charsonly: true
                },
                lastname: {
                    required: true,
                    charsonly: true
                },
                email: {
                    required: true,
                    email: true
                },
                description: {
                    required: true,
                },
                contactno: {
                    required: true,
                    phoneUS: true
                }
            },
            messages: {
                firstname: {
                    required: "FirstName field  is required.",
                },
                lastname: {
                    required: "LastName field  is required.",
                },
                email: {
                    required: "email field  is required.",
                    email: "please enter the valid email"
                },
                contactno: {
                    required: "phone no field  is required.",
                },
                description: {
                    required: "message mustbe required"
                }
            },
            submitHandler: function (form) {
                form.submit();
            }
        }
    );
    //jQuery.validator.addMethod("charsonly", function (value) {
    //    return /^[a-z]+$/i.test(value);
    //}, "please enter characters only");
});
