/// <binding AfterBuild='build' Clean='clean' />

const del = require('del');
const gulp = require('gulp');
const concat = require('gulp-concat');
const cssmin = require('gulp-cssmin');
const terser = require('gulp-terser');
const through = require('through2');

function clean() {
    return del(['wwwroot/app.min.css', 'wwwroot/app.min.js']);
}

function styles() {
    return gulp.src('wwwroot/app.css')
        .pipe(cssmin())
        .pipe(concat('app.min.css'))
        .pipe(gulp.dest('wwwroot/'));
}

function scripts() {
    return gulp.src('wwwroot/app.js')
        .pipe(terser())
        .pipe(removeSpaces())
        .pipe(concat('app.min.js'))
        .pipe(gulp.dest('wwwroot/'));
}

function removeSpaces() {
    return through.obj((vinylFile, encoding, callback) => {
        var newFile = vinylFile.clone();
        if (newFile.contents !== null) {
            const text = newFile.contents.toString('utf-8');
            const result = text.replace(/\s+/g, ' ');
            newFile.contents = Buffer.from(result);
            callback(null, newFile);
        }
    })
}

exports.clean = clean;
exports.styles = styles;
exports.scripts = scripts;

var build = gulp.series(clean, gulp.parallel(styles, scripts));
gulp.task('build', build);
