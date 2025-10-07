import type { NextConfig } from "next";

const nextConfig: NextConfig = {
  reactStrictMode: true,
  webpack(config) {
    config.watchOptions = {
      ignored: [
        "**/node_modules",
        "C:/DumpStack.log.tmp",
        "C:/hiberfil.sys",
        "C:/swapfile.sys",
        "C:/pagefile.sys"
      ]
    };
    return config;
  }
};

export default nextConfig;