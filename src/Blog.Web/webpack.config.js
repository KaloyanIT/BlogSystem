const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const extractCSS = new ExtractTextPlugin('allstyles.css');

module.exports = {
    mode: 'development',
    target: 'web',
    entry: { bundle: './Scripts/entry.tsx' },
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: '[name].js',
        publicPath: '/dist/'
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
            { test: /\.tsx{0,1}$/, loader: 'ts-loader', options: { configFile: 'tsconfig.json' } },
            { test: /\.jsx$/, loader: 'babel-loader', options: { presets: ['@babel/react', ['@babel/env', { 'targets': { 'browsers': '> 5%' } }]] } }

        ]

    },
    resolve: {
        extensions: ['.ts', '.tsx', '.jsx', '.js'] // with this, you don't need extension when importing modules
    }
};