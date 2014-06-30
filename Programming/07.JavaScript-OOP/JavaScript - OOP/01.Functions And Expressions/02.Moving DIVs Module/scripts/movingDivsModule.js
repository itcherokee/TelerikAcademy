var movingShapes = (function () {
    function generateNumberInRange(min, max, isAngle) {
        var result = (Math.random() * (max - min) + min);
        if (!isAngle) {
            result = result | 0;
        }

        return result;
    }

    function generateColor() {
        return  'rgb(' + generateNumberInRange(0, 255) + ',' + generateNumberInRange(0, 255) + ',' + generateNumberInRange(0, 255) + ')';
    }

    function Shape(name) {
        var ELEMENT_SIZE = 100;

        function createShape(name) {
            var element = document.createElement('div');
            element.style.backgroundColor = generateColor();
            element.style.border = '2px solid ' + generateColor();
            element.style.width = ELEMENT_SIZE + 'px';
            element.style.height = ELEMENT_SIZE + 'px';
            element.style.position = 'absolute';
            element.style.top = generateNumberInRange(ELEMENT_SIZE, window.innerHeight - 3 * ELEMENT_SIZE) + 'px';
            element.style.left = generateNumberInRange(ELEMENT_SIZE, window.innerWidth - 3 * ELEMENT_SIZE) + 'px';
            if (name == 'ellipse') {
                element.style.borderRadius = ELEMENT_SIZE + 'px';
            }

            return element;
        }

        this.elementSize = ELEMENT_SIZE;
        this.shape = createShape(name);
        this.shapeType = name;
        this.angle = 0;
        this.direction = 0;
        this.angleOffset = generateNumberInRange(0.01, 0.05, true);
        this.rotatingCenter = [parseInt(this.shape.style.left) + this.elementSize, parseInt(this.shape.style.top) + this.elementSize];
        this.move = function () {
            if (this.shapeType === 'rect') {
                var offsetX = [2, 0, -2, 0],
                    offsetY = [0, 2, 0, -2];

                if (parseInt(this.shape.style.left) > this.rotatingCenter[0] + this.elementSize && this.direction !== 1) {
                    this.shape.style.left = this.rotatingCenter[0] + this.elementSize + 'px';
                    this.direction = 1;
                }

                if (parseInt(this.shape.style.top) > this.rotatingCenter[1] + this.elementSize && this.direction !== 2) {
                    this.shape.style.top = this.rotatingCenter[1] + this.elementSize + 'px';
                    this.direction = 2;
                }

                if (parseInt(this.shape.style.left) < this.rotatingCenter[0] - this.elementSize && this.direction !== 3) {
                    this.shape.style.left = this.rotatingCenter[0] - this.elementSize + 'px';
                    this.direction = 3;
                }

                if (parseInt(this.shape.style.top) < this.rotatingCenter[1] - this.elementSize && this.direction !== 0) {
                    this.shape.style.top = this.rotatingCenter[1] - this.elementSize + 'px';
                    this.direction = 0;
                }

                this.shape.style.top = parseInt(this.shape.style.top) + offsetY[this.direction] + 'px';
                this.shape.style.left = parseInt(this.shape.style.left) + offsetX[this.direction] + 'px';
            } else {
                function getPath(path) {
                    return {
                        x: path.x + path.radius * Math.cos(path.angle),
                        y: path.y + path.radius * Math.sin(path.angle)
                    };
                }

                this.angle += this.angleOffset;
                var newPoint = getPath({
                    x: this.rotatingCenter[0],
                    y: this.rotatingCenter[1],
                    radius: this.elementSize,
                    angle: this.angle + 2 * Math.PI
                });
                this.shape.style.top = newPoint.y + 'px';
                this.shape.style.left = newPoint.x + 'px';
            }

            var currentElement = this;
            setTimeout(function () {
                currentElement.move()
            }, 20);
        }
    }

    function add(shapeType) {
        var figure;
        switch (shapeType) {
            case 'rect':
                figure = new Shape('rect');
//                moveRect(shape);
                break;
            case 'ellipse':
                figure = new Shape('ellipse');
//                moveEllipse(shape);
                break;
        }

        figure.move();
        document.body.appendChild(figure.shape);
    }

    return {
        add: add
    };
})();