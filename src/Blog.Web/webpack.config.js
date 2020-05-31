const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

const bundleFileName = 'bundle';
const dirName = 'StaticFiles/dist';

module.exports = (env, argv) => {
    return {
        mode: argv.mode === "production" ? "production" : "development",
        entry: ['./StaticFiles/src/index.js', './StaticFiles/src/sass/index.scss'],
        output: {
            path: path.resolve(__dirname, dirName),
            publicPath: '/',
            filename: 'bundle.js'
        },
        module: {
            rules: [
                {
                    test: /\.(js)$/,
                    exclude: /node_modules/,
                    use: ['babel-loader']
                },
                {
                    test: /\.s[c|a]ss$/,
                    use:
                        [
                            'style-loader',
                            MiniCssExtractPlugin.loader,
                            'css-loader',
                            {
                                loader: 'postcss-loader',
                                options: {
                                    config: {
                                        ctx: {
                                            env: argv.mode
                                        }
                                    }
                                }
                            },
                            'sass-loader'
                        ]
                }
            ]
        },
        resolve: {
            extensions: ['*', '.js']
          },
          devServer: {
            contentBase: './dist'
          },
        plugins: [
            new CleanWebpackPlugin(),
            new MiniCssExtractPlugin({
                filename: bundleFileName + '.css'
            })
        ]
    };
};