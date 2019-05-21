const path = require("path")

module.exports = {
    mode: "development",
    entry: {main: "./wwwroot/src/index.js"},
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /(node_modules|bower_components)/,
                loader: "babel-loader",
                options: {
                    presets: ["@babel/env"]
                }
            },
            {
                test: /\.css$/,
                loader: "style-loader"
            },
            {
                test: /\.css$/,
                loader: "css-loader",
                query: {
                    modules: true
                }
            },
            {
                test: /\.(png|svg|jpg|gif)$/,
                use: ["file-loader"]
            }
        ]
    },
    resolve: {
        extensions: [
            "*",
            ".js",
            ".jsx",
            ".css"
        ],
        alias: {
            root: path.resolve(__dirname, "wwwroot")
        }
    },
    output: {
        path: path.resolve(__dirname, "wwwroot/dist"),
        filename: "bundle.js",
        publicPath: "dist/"
    },
    devtool: "inline-source-map: true"
}
