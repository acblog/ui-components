properties {
    $NUGET_AUTH_TOKEN = $NUGET_AUTH_TOKEN
    $build_version = $build_version
}

Task default -depends Restore, Build

Task Deploy -depends Deploy-packages

Task CI -depends Install-deps, Restore, Build, Test, Benchmark, Report

Task CD -depends Install-deps, Restore, Build, Pack, Deploy

Task Restore -depends Restore-Slides, Restore-Loading {
    Exec { dotnet restore }
}

Task Build {
    Exec { dotnet build -c Release /p:Version=$build_version }
}

Task Install-deps {
    Exec { dotnet nuget add source https://sparkshine.pkgs.visualstudio.com/StardustDL/_packaging/feed/nuget/v3/index.json -n aza -u sparkshine -p $NUGET_AUTH_TOKEN --store-password-in-clear-text }
    Exec { npm install --global gulp }
    Exec { dotnet tool install --global Microsoft.Web.LibraryManager.Cli }
    Exec { dotnet tool install dotnet-reportgenerator-globaltool --tool-path ./tools }
}

Task Test {
    if (-not (Test-Path -Path "reports/test")) {
        New-Item -Path "reports/test" -ItemType Directory
    }
    Exec { dotnet test -c Release /p:CollectCoverage=true /p:CoverletOutput=../../reports/test/coverage.json /p:MergeWith=../../reports/test/coverage.json /maxcpucount:1 }
    Exec { dotnet test -c Release ./test/Test.Base /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../../reports/test/coverage.xml /p:MergeWith=../../reports/test/coverage.json }
}

Task Benchmark { 
    Exec { dotnet run -c Release --project ./test/Benchmark.Base }
}

Task Report {
    Exec { ./tools/reportgenerator -reports:./reports/test/coverage.xml -targetdir:./reports/test }
    if (-not (Test-Path -Path "reports/benchmark")) {
        New-Item -Path "reports/benchmark" -ItemType Directory
    }
    Copy-Item ./BenchmarkDotNet.Artifacts/* ./reports/benchmark -Recurse
}

Task Pack {
    if (-not (Test-Path -Path "packages")) {
        New-Item -Path "packages" -ItemType Directory
    }

    Exec -maxRetries 3 { dotnet pack -c Release /p:Version=$build_version -o ./packages }
}

Task NPMUP? {
    Set-Location src/AcBlog.UI.Components.Loading
    Exec { ncu }
    Set-Location ../..
}

Task NPMUP {
    Set-Location src/AcBlog.UI.Components.Loading
    Exec { ncu -u }
    Exec { npm i }
    Set-Location ../..
}

Task Deploy-packages {
    Exec { dotnet nuget push ./packages/AcBlog.Extensions.Core.$build_version.nupkg -s aza -k az }
    Exec { dotnet nuget push ./packages/AcBlog.UI.Components.Core.$build_version.nupkg -s aza -k az }
    Exec { dotnet nuget push ./packages/AcBlog.UI.Components.Loading.$build_version.nupkg -s aza -k az }
    # Exec { dotnet nuget push ./packages/AcBlog.UI.Components.Markdown.$build_version.nupkg -s aza -k az }
    Exec { dotnet nuget push ./packages/AcBlog.UI.Components.Slides.$build_version.nupkg -s aza -k az }
    # Exec { dotnet nuget push ./packages/AcBlog.UI.Components.Modal.$build_version.nupkg -s aza -k az }
    # Exec { dotnet nuget push ./packages/AcBlog.UI.Components.Toast.$build_version.nupkg -s aza -k az }
    # Exec { dotnet nuget push ./packages/AcBlog.UI.Components.Bootstrap.$build_version.nupkg -s aza -k az }
    # Exec { dotnet nuget push ./packages/AcBlog.UI.Components.AntDesigns.$build_version.nupkg -s aza -k az }
}

Task Restore-Slides {
    Set-Location src/AcBlog.UI.Components.Slides
    Exec { libman restore }
    Set-Location ../..
}

Task Restore-Loading {
    Set-Location src/AcBlog.UI.Components.Loading
    Exec { npm ci }
    Exec { gulp }
    Set-Location ../..
}
