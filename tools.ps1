if ($args.Count -gt 0) {
    switch ($args[0]) {
        "npmup?" {
            Set-Location src/AcBlog.UI.Components.Loading && ncu && Set-Location ../.. || exit 1
        }
        "npmup" {
            Set-Location src/AcBlog.UI.Components.Loading && ncu -u && npm install && Set-Location ../.. || exit 1
        }
        "restore" {
            Write-Output "Restore npm..."
            Set-Location src/AcBlog.UI.Components.Slides && libman restore && Set-Location ../.. || exit 1
            Set-Location src/AcBlog.UI.Components.Loading && npm ci && gulp && Set-Location ../.. || exit 1
            dotnet restore || exit 1
        }
        "pack" {
            mkdir packages || exit 1
            dotnet pack -c Release /p:Version=${env:build_version} -o ./packages && exit 0
            dotnet pack -c Release /p:Version=${env:build_version} -o ./packages && exit 0
            dotnet pack -c Release /p:Version=${env:build_version} -o ./packages || exit 1
        }
        "format" {
            Write-Output "Format..."
            dotnet format || exit 1
        }
        "dev-deps" {
            Write-Output "Install dev deps..."
            dotnet nuget add source https://sparkshine.pkgs.visualstudio.com/StardustDL/_packaging/feed/nuget/v3/index.json -n aza -u sparkshine -p $env:NUGET_AUTH_TOKEN --store-password-in-clear-text || exit 1
            npm install --global gulp || exit 1
            dotnet tool install --global Microsoft.Web.LibraryManager.Cli || exit 1
            dotnet tool install dotnet-reportgenerator-globaltool --tool-path ./tools || exit 1
        }
        "report" {
            ./tools/reportgenerator -reports:./reports/test/coverage.xml -targetdir:./reports/test || exit 1
            if (-not (Test-Path -Path "reports/benchmark")) {
                New-Item -Path "reports/benchmark" -ItemType Directory || exit 1
            }
            Copy-Item ./BenchmarkDotNet.Artifacts/* ./reports/benchmark -Recurse || exit 1
        }
        "test" {
            Write-Output "Test..."
            if (-not (Test-Path -Path "reports/test")) {
                New-Item -Path "reports/test" -ItemType Directory || exit 1
            }
            dotnet test -c Release /p:CollectCoverage=true /p:CoverletOutput=../../reports/test/coverage.json /p:MergeWith=../../reports/test/coverage.json /maxcpucount:1 || exit 1
            dotnet test -c Release ./test/Test.Base /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../../reports/test/coverage.xml /p:MergeWith=../../reports/test/coverage.json || exit 1
        }
        "benchmark" {
            Write-Output "Benchmark..."
            dotnet run -c Release --project ./test/Benchmark.Base || exit 1
        }
        Default {
            Write-Output "Unrecognized command"
            exit -1
        }
    }
}
else {
    Write-Output "Missing command"
    exit -1
}