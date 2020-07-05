const path = require('path');
const webpack = require('webpack');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

const bundleFileName = 'bundle';
const dirName = 'StaticFiles/dist';


module.exports = {
  mode: 'development',
  // prettier-ignore
  entry: {
      // Admin
      'js/admin/blog': './StaticFiles/src/js/admin/blog.js',

      //Front-end
      'js/front-end/comments': './StaticFiles/src/js/front-end/comments.js',


      'js/common/dropdown': './StaticFiles/src/js/common/dropdown.js',
      'js/common/data': './StaticFiles/src/js/common/data.js',
      'js/common/validator': './StaticFiles/src/js/common/validator.js',
      'js/common/logger': './StaticFiles/src/js/common/logger.js',



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
