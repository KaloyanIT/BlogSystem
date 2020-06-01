const path = require('path');
<<<<<<< HEAD
const webpack = require('webpack');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
=======
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
>>>>>>> 619ef0e... Add TinyMCE and webpack libraries
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

const bundleFileName = 'bundle';
const dirName = 'StaticFiles/dist';

<<<<<<< HEAD
module.exports = {
  mode: 'development',
  // prettier-ignore
  entry: {
      // Admin
      'js/admin/blog': './StaticFiles/src/js/admin/blog.js',


      'bundle': './StaticFiles/src/js/bundle.js',
      'js/text-editor' : './StaticFiles/src/js/text-editor.js',
      'scss/entry': './StaticFiles/src/scss/entry.scss',
    },
  output: {
    path: path.resolve(__dirname, dirName),
    publicPath: '/js/',
    filename: '[name].js',
  },
  module: {
    rules: [
      {
        test: /\.(js)$/,
        exclude: /node_modules/,
        use: ['babel-loader', 'eslint-loader'],
      },
      {
        test: /\.s[c|a]ss$/,
        use: [
          'style-loader',
          MiniCssExtractPlugin.loader,
          'css-loader',
          {
            loader: 'postcss-loader',
            options: {
              config: {
                ctx: {
                  env: 'development',
                },
              },
            },
          },
          'sass-loader',
        ],
      },
      {
        test: /\.(woff|woff2)$/,
        use: {
          loader: 'url-loader',
        },
      },
      {
        test: require.resolve('jquery'),
        use: [
          {
            loader: 'expose-loader',
            options: 'jQuery',
          },
          {
            loader: 'expose-loader',
            options: '$',
          },
        ],
      },
    ],
  },
  resolve: {
    modules: [
      path.resolve('./StaticFiles/src/js'),
      path.resolve('./node_modules'),
    ],
    extensions: ['.js'],
  },
  devServer: {
    contentBase: './dist',
  },
  plugins: [
    new CleanWebpackPlugin(),
    new webpack.SourceMapDevToolPlugin(),
    new webpack.ProvidePlugin({
      $: 'jquery',
      jQuery: 'jquery',
    }),
    new MiniCssExtractPlugin({
      filename: bundleFileName + '.css',
    }),
  ],
  // externals: {
  //   jquery: 'jQuery',
  // },
};
=======
module.exports = (env, argv) => {
    return {
        mode: argv.mode === "production" ? "production" : "development",
        entry: ['./StaticFiles/src/index.js', './StaticFiles/src/sass/index.scss'],
        output: {
            filename: bundleFileName + '.js',
            path: path.resolve(__dirname, dirName)
        },
        module: {
            rules: [
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
        plugins: [
            new CleanWebpackPlugin(),
            new MiniCssExtractPlugin({
                filename: bundleFileName + '.css'
            })
        ]
    };
};
>>>>>>> 619ef0e... Add TinyMCE and webpack libraries
