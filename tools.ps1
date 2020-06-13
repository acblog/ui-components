if ($args.Count -gt 0) {
    switch ($args[0]) {
        "npmup?" {
            Set-Location src/AcBlog.UI.Components.Markdown && ncu && Set-Location ../..
            if (!$?) {
                exit 1
            }
            Set-Location src/AcBlog.UI.Components.Loading && ncu && Set-Location ../..
            if (!$?) {
                exit 1
            }
        }
        "npmup" {
            Set-Location src/AcBlog.UI.Components.Markdown && ncu -u && npm install && Set-Location ../..
            if (!$?) {
                exit 1
            }
            Set-Location src/AcBlog.UI.Components.Loading && ncu -u && npm install && Set-Location ../..
            if (!$?) {
                exit 1
            }
        }
        "restore" {
            Write-Output "Restore npm..."
            Set-Location src/AcBlog.UI.Components.Markdown && npm ci && gulp && Set-Location ../..
            if (!$?) {
                exit 1
            }
            Set-Location src/AcBlog.UI.Components.Slides && libman restore && Set-Location ../..
            if (!$?) {
                exit 1
            }
            Set-Location src/AcBlog.UI.Components.Loading && npm ci && gulp && Set-Location ../..
            if (!$?) {
                exit 1
            }
            dotnet restore
            if (!$?) {
                exit 1
            }
        }
        "pack" {
            mkdir packages
            dotnet pack -c Release /p:Version=${env:build_version} -o ./packages
            if ($?) {
                exit 0
            }
            Write-Output "Retry packing..."
            dotnet pack -c Release /p:Version=${env:build_version} -o ./packages
            if ($?) {
                exit 0
            }
            Write-Output "Retry packing..."
            dotnet pack -c Release /p:Version=${env:build_version} -o ./packages
            if (!$?) {
                exit 1
            }
        }
        "format" {
            Write-Output "Format..."
            dotnet format
            if (!$?) {
                exit 1
            }
        }
        "test" {
            Write-Output "Test..."
            dotnet test /p:CollectCoverage=true
            if (!$?) {
                exit 1
            }
        }
        "benchmark" {
            Write-Output "Benchmark"
            dotnet run -c Release --project ./test/Benchmark.Base
            if (!$?) {
                exit 1
            }
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