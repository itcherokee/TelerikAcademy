var drawModule = (function () {
    var canvas = document.getElementById('playground');
    var ctx = canvas.getContext('2d');

    this.drawShape = function (shape) {
        shape.draw(ctx);
    };
    return this;
})();

function Rect(topLeftPoint, width, height, color) {
    var self = this;
    self.x = topLeftPoint.x;
    self.y = topLeftPoint.y;
    self.width = width;
    self.height = height;
    self.draw = function (ctx) {
        ctx.fillStyle = color;
        ctx.strokeStyle = 'black';
        ctx.lineWidth = 5;
        ctx.fillRect(self.x, self.y, self.width, self.height);
        ctx.strokeRect(self.x, self.y, self.width, self.height);
    };
}

function Circle(centerPoint, radius, color) {
    var self = this;
    self.cx = centerPoint.x;
    self.cy = centerPoint.y;
    self.radius = radius;
    self.draw = function (ctx) {
        ctx.beginPath();
        ctx.fillStyle = color;
        ctx.strokeStyle = 'black';
        ctx.lineWidth = 5;
        ctx.arc(self.cx, self.cy, self.radius, 0, 2 * Math.PI, false);
        ctx.fill();
        ctx.stroke();
    };
}

function Line(startPoint, endPoint, color) {
    var self = this;
    self.start = startPoint;
    self.end = endPoint;
    self.draw = function (ctx) {
        ctx.beginPath();
        ctx.strokeStyle = color;
        ctx.lineWidth = 5;
        ctx.moveTo(self.start.x,self.start.y);
        ctx.lineTo(self.end.x,self.end.y);
        ctx.stroke();
    };
}

function Point(x, y) {
    this.x = x;
    this.y = y;
}

