export function print() {
    let printContents, popupWin;
    printContents = document.getElementById('billPrintView').innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=500,width=330');
    popupWin.document.open();
    popupWin.document.write(`
          <html>
            <head>
            <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" media="print">
            </head>
            
        <body>
<style>
    /* -------------------------------------
                    GLOBAL
                    A very basic CSS reset
                ------------------------------------- */
    * {
        margin: 0;
        padding: 0;
        font-family: "Helvetica Neue", "Helvetica", Helvetica, Arial, sans-serif;
        box-sizing: border-box;
        font-size: 14px;
    }

    img {
        max-width: 100%;
    }

    body {
        -webkit-font-smoothing: antialiased;
        -webkit-text-size-adjust: none;
        width: 100% !important;
        height: 100%;
        line-height: 1.6;
    }

    /* Let's make sure all tables have defaults */
    table td {
        vertical-align: top;
    }

    /* -----------------------------------BODY & CONTAINER------------------------------ */
    body {
        background-color: #f6f6f6;
    }

    .body-wrap {
        background-color: #f6f6f6;
        width: 100%;
    }

    .container {
        display: block !important;
        max-width: 600px !important;
        margin: 0 auto !important;
        /* makes it centered */
        clear: both !important;
    }

    .content {
        max-width: 600px;
        margin: 0 auto;
        display: block;
        /*padding: 20px;*/
    }

    /* -------------------------------------HEADER, FOOTER, MAIN----------------------------------- */
    .main {
        background: #fff;
        border: 1px solid #e9e9e9;
        border-radius: 3px;
    }

    .content-wrap {
        /*padding: 20px;*/
    }

    .content-block {
        padding: 0 0 2px;
    }

    .header {
        width: 100%;
        margin-bottom: 10px;
    }

    .footer {
        width: 100%;
        clear: both;
        color: #999;
        padding: 10px;
    }

        .footer a {
            color: #999;
        }

        .footer p, .footer a, .footer unsubscribe, .footer td {
            font-size: 12px;
        }

    /* ---------------------------------TYPOGRAPHY----------------------------------- */
    h1, h2, h3 {
        font-family: "Helvetica Neue", Helvetica, Arial, "Lucida Grande", sans-serif;
        color: #000;
        margin: 40px 0 0;
        line-height: 1.2;
        font-weight: 400;
    }

    h1 {
        font-size: 32px;
        font-weight: 500;
    }

    h2 {
        font-size: 24px;
    }

    h3 {
        font-size: 18px;
    }

    h4 {
        font-size: 14px;
        font-weight: 600;
    }

    p, ul, ol {
        margin-bottom: 10px;
        font-weight: normal;
    }

        p li, ul li, ol li {
            margin-left: 5px;
            list-style-position: inside;
        }

    /* ------------------------------------LINKS & BUTTONS------------------------------------ */
    a {
        color: #1ab394;
        text-decoration: underline;
    }

    .btn-primary {
        text-decoration: none;
        color: #FFF;
        background-color: #1ab394;
        border: solid #1ab394;
        border-width: 5px 10px;
        line-height: 2;
        font-weight: bold;
        text-align: center;
        cursor: pointer;
        display: inline-block;
        border-radius: 5px;
        text-transform: capitalize;
    }

    /* -------------------------------------OTHER STYLES THAT MIGHT BE USEFUL------------------------ */
    .last {
        margin-bottom: 0;
    }

    .first {
        margin-top: 0;
    }

    .aligncenter {
        text-align: center;
    }

    .alignright {
        text-align: right;
    }

    .alignleft {
        text-align: left;
    }

    .clear {
        clear: both;
    }

    /* ----ALERTS Change the class depending on warning email, good email or bad email------- */
    .alert {
        font-size: 16px;
        color: #fff;
        font-weight: 500;
        padding: 20px;
        text-align: center;
        border-radius: 3px 3px 0 0;
    }

        .alert a {
            color: #fff;
            text-decoration: none;
            font-weight: 500;
            font-size: 16px;
        }

        .alert.alert-warning {
            background: #f8ac59;
        }

        .alert.alert-bad {
            background: #ed5565;
        }

        .alert.alert-good {
            background: #1ab394;
        }

    /* ---------------------------------INVOICE Styles for the billing table--------------------- */
    .invoice {
        margin: auto;
        text-align: left;
        width: 95%;
    }

        .invoice td {
            padding: 5px 0;
        }

        

        .invoice .invoice-items {
            width: 100%;
        }

            .invoice .invoice-items td {
                border-top: #eee 1px solid;
                /*border-bottom: #eee 1px solid;*/
            }

            .invoice .invoice-items th {
                font-size: 16px;
        }

        .invoice .total td {
            border-top: 1px solid #333;
            /*border-bottom: 2px solid #333;*/
            font-weight: 700;
        }

</style>


            ${printContents}


        </body>

          </html>`
    );


    //popupWin.document.close();
}










//<style>

///* -------------------------------------
//    RESPONSIVE AND MOBILE FRIENDLY STYLES
//    ------------------------------------- */
//    @media print {
//      .col - sm - 1, .col - sm - 2, .col - sm - 3, .col - sm - 4, .col - sm - 5, .col - sm - 6,
//      .col - sm - 7, .col - sm - 8, .col - sm - 9, .col - sm - 10, .col - sm - 11, .col - sm - 12 {
//        float: left;
//      }

//    .col-sm-12 {
//        width: 100%;
//      }

//    .col-sm-11 {
//        width: 91.66666666666666%;
//      }

//    .col-sm-10 {
//        width: 83.33333333333334%;
//      }

//    .col-sm-9 {
//        width: 75%;
//      }

//    .col-sm-8 {
//        width: 66.66666666666666%;
//      }

//    .col-sm-7 {
//        width: 58.333333333333336%;
//       }

//    .col-sm-6 {
//        width: 50%;
//       }

//    .col-sm-5 {
//        width: 41.66666666666667%;
//       }

//    .col-sm-4 {
//        width: 33.33333333333333%;
//       }

//    .col-sm-3 {
//        width: 25%;
//       }

//    .col-sm-2 {
//        width: 16.666666666666664%;
//       }

//    .col-sm-1 {
//        width: 8.333333333333332%;
//        }
//    h1, h2, h3, h4 {
//        font - weight: 600 !important;
//    margin-top: 10px !important;
//    text-align: center;
//    }

//    h1 {
//        font - size: 22px !important;
//    }

//    h2 {
//        font - size: 18px !important;
//    }

//    h3 {
//        font - size: 16px !important;
//    }

//    .container {
//        width: 100% !important;
//    }

//    .content, .content-wrap {
//        padding: 10px !important;
//    }

//    .invoice {
//        width: 100% !important;
//    }

//    /* -------------------------------------
//                        GLOBAL
//                        A very basic CSS reset
//                    ------------------------------------- */
//    * {
//        margin: 0;
//    padding: 0;
//    font-family: "Helvetica Neue", "Helvetica", Helvetica, Arial, sans-serif;
//    box-sizing: border-box;
//    font-size: 14px;
//    }

//    img {
//        max - width: 100%;
//    }

//    body {
//        -webkit - font - smoothing: antialiased;
//    -webkit-text-size-adjust: none;
//    width: 100% !important;
//    height: 100%;
//    line-height: 1.6;
//    }

//    /* Let's make sure all tables have defaults */
//    table td {
//        vertical - align: top;
//    }

//    /* -----------------------------------BODY & CONTAINER------------------------------ */
//    body {
//        background - color: #f6f6f6;
//    }

//    .body-wrap {
//        background - color: #f6f6f6;
//    width: 100%;
//    }

//    .container {
//        display: block !important;
//    max-width: 600px !important;
//    margin: 0 auto !important;
//    /* makes it centered */
//    clear: both !important;
//    }

//    .content {
//        max - width: 600px;
//    margin: 0 auto;
//    display: block;
//        /*padding: 20px;*/
//    }

//    /* -------------------------------------HEADER, FOOTER, MAIN----------------------------------- */
//    .main {
//        background: #fff;
//    border: 1px solid #e9e9e9;
//    border-radius: 3px;
//    }

//    .content-wrap {
//        /*padding: 20px;*/
//    }

//    .content-block {
//        padding: 0 0 2px;
//    }

//    .header {
//        width: 100%;
//    margin-bottom: 10px;
//    }

//    .footer {
//        width: 100%;
//    clear: both;
//    color: #999;
//    padding: 10px;
//    }

//    .footer a {
//        color: #999;
//        }

//    .footer p, .footer a, .footer unsubscribe, .footer td {
//        font - size: 12px;
//        }

//    /* ---------------------------------TYPOGRAPHY----------------------------------- */
//    h1, h2, h3 {
//        font - family: "Helvetica Neue", Helvetica, Arial, "Lucida Grande", sans-serif;
//    color: #000;
//    margin: 40px 0 0;
//    line-height: 1.2;
//    font-weight: 400;
//    }

//    h1 {
//        font - size: 32px;
//    font-weight: 500;
//    }

//    h2 {
//        font - size: 24px;
//    }

//    h3 {
//        font - size: 18px;
//    }

//    h4 {
//        font - size: 14px;
//    font-weight: 600;
//    }

//    p, ul, ol {
//        margin - bottom: 10px;
//    font-weight: normal;
//    }

//    p li, ul li, ol li {
//        margin - left: 5px;
//    list-style-position: inside;
//        }

//    /* ------------------------------------LINKS & BUTTONS------------------------------------ */
//    a {
//        color: #1ab394;
//    text-decoration: underline;
//    }

//    .btn-primary {
//        text - decoration: none;
//    color: #FFF;
//    background-color: #1ab394;
//    border: solid #1ab394;
//    border-width: 5px 10px;
//    line-height: 2;
//    font-weight: bold;
//    text-align: center;
//    cursor: pointer;
//    display: inline-block;
//    border-radius: 5px;
//    text-transform: capitalize;
//    }

//    /* -------------------------------------OTHER STYLES THAT MIGHT BE USEFUL------------------------ */
//    .last {
//        margin - bottom: 0;
//    }

//    .first {
//        margin - top: 0;
//    }

//    .aligncenter {
//        text - align: center;
//    }

//    .alignright {
//        text - align: right;
//    }

//    .alignleft {
//        text - align: left;
//    }

//    .clear {
//        clear: both;
//    }

//    /* ----ALERTS Change the class depending on warning email, good email or bad email------- */
//    .alert {
//        font - size: 16px;
//    color: #fff;
//    font-weight: 500;
//    padding: 20px;
//    text-align: center;
//    border-radius: 3px 3px 0 0;
//    }

//    .alert a {
//        color: #fff;
//    text-decoration: none;
//    font-weight: 500;
//    font-size: 16px;
//        }

//    .alert.alert-warning {
//        background: #f8ac59;
//        }

//    .alert.alert-bad {
//        background: #ed5565;
//        }

//    .alert.alert-good {
//        background: #1ab394;
//        }

//    /* ---------------------------------INVOICE Styles for the billing table--------------------- */
//    .invoice {
//        margin: auto;
//    text-align: left;
//    width: 95%;
//    }

//    .invoice td {
//        padding: 5px 0;
//        }

//    .invoice .invoice-items {
//        width: 100%;
//        }

//    .invoice .invoice-items td {
//        border - top: #eee 1px solid;
//                /*border-bottom: #eee 1px solid;*/
//            }

//    .invoice .total td {
//        border - top: 1px solid #333;
//    /*border-bottom: 2px solid #333;*/
//    font-weight: 700;
//        }
//}


//</style>