(function () {
    var isWin8 = (typeof (MSApp) === "object");

    function _shimNodes(nodes, obj) {
        if (!nodes)
            return;
        if (nodes.nodeType) {
            obj[obj.length++] = nodes;
            return;
        }
        for (var i = 0, iz = nodes.length; i < iz; i++)
            obj[obj.length++] = nodes[i];
    }

    /**
         * $.create - a faster alertnative to $("<div id='main'>this is some text</div>");
          ```
          $.create("div",{id:'main',innerHTML:'this is some text'});
          $.create("<div id='main'>this is some text</div>");
          ```
          * @param {String} DOM Element type or html
          * @param [{Object}] properties to apply to the element
          * @return {Object} Returns an appframework object
          * @title $.create(type,[params])
          */
    $.create = function (type, props) {
        var elem;
        var f = new $();
        if (props || type[0] !== "<") {
            if (props) {
                if (props.html) {
                    props.innerHTML = props.html;
                    delete props.html;
                }
            }

            elem = document.createElement(type);
            for (var j in props) {
                elem[j] = props[j];
            }
            f[f.length++] = elem;
        } else {
            elem = document.createElement("div");
            if (isWin8) {
                MSApp.execUnsafeLocalFunction(function () {
                    elem.innerHTML = type.trim();
                });
            } else
                elem.innerHTML = type;
            _shimNodes(elem.childNodes, f);
        }
        return f;
    };
})();//$.create