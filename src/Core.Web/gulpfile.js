///// <binding BeforeBuild='default' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var rimraf = require("rimraf");
var merge = require('merge-stream');
var csso = require('gulp-csso');

// Dependency Dirs
var dependenciesDirectory = require("./dependencies.Directory.json");
var package = require("./package.json");
var dependencies = package.dependencies;

var theme = 'default';

gulp.task("minify-js", function () {
    var streams = [
        gulp.src(["wwwroot/themes/" + theme + "/js/scripts.js"])
            .pipe(uglify())
            .pipe(concat("scripts.min.js"))
            .pipe(gulp.dest("wwwroot/themes/" + theme + "/js/"))
    ];
    return merge(streams);
});

gulp.task("minify-css", function () {
    return gulp.src('wwwroot/themes/' + theme + '/css/styles.css')
        .pipe(csso())
        .pipe(concat("styles.min.css"))
        .pipe(gulp.dest('wwwroot/themes/' + theme + '/css/'));
});

gulp.task("minify", gulp.parallel('minify-js', 'minify-css'));

gulp.task("clean-vendor", function (cb) {
    return rimraf("wwwroot/vendor/", cb);
});

gulp.task("clean", gulp.parallel('clean-vendor'));

gulp.task("scripts", function () {
    var streams = [];

    for (var prop in dependencies) {
        console.log("Prepping Scripts for: " + prop);
        if (prop in dependenciesDirectory) {
            for (var itemProp in dependenciesDirectory[prop]) {
                streams.push(gulp.src("node_modules/" + prop + "/" + itemProp)
                    .pipe(gulp.dest("wwwroot/vendor/" + prop + "/" + dependenciesDirectory[prop][itemProp])));
            }
        } else {
            streams.push(gulp.src(["node_modules/" + prop + "/**/*", "node_modules/" + prop + "/*"])
                .pipe(gulp.dest("wwwroot/vendor/" + prop + "/")));
        }
    }

    return merge(streams);
});

gulp.task('watch', function () {
    gulp.watch(['wwwroot/themes/' + theme + '/css/styles.css', "wwwroot/themes/" + theme + "/js/scripts.js"]).on('change', function (file) {
        console.log('file changed: ', file);
        gulp.series("minify")();
    });
});

gulp.task('default',
    gulp.series('clean', gulp.parallel('minify', 'scripts'))
);