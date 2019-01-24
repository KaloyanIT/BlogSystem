const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const extractCSS = new ExtractTextPlugin('allstyles.css');

module.exports = {
    entry: { 'main': './wwwroot/js/app.js'},
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js',
        publicPath: 'dist/'
    },
    plugins: [
        extractCSS,
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery',
            Popper: ['popper.js', 'default']
        })
    ],
    optimization: {
        minimize: true
    },
    module: {
        rules: [
            {
                test: /\.css$/, use: extractCSS.extract(['css-loader'])
            },
            {
                test: /\.js?$/,
                use: {
                    loader: 'babel-loader', options: {
                        presets:
                            ['@babel/preset-react', '@babel/preset-env']
                    }
                }
            },

        ]

    }
};