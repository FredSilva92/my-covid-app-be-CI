pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/core/sdk:3.1'
        }
    }

    environment {
        MY_REPO = 'https://github.com/FredSilva92/my-covid-app-be.git';
        CI_REPO = '${GITHUB_TOKEN}@github.com:FredSilva92/my-covid-app-be-CI.git';
    }

    stages {
        stage('SCM checkout') {
            steps {
                //sh 'git remote rm ci-repo'
                //sh 'git fetch --all'
                //sh 'git remote add ci-repo $CI_REPO'
                //sh 'git remote update'
                sh 'git branch -a'
                sh 'git checkout origin/master'
                sh 'git merge ci-repo/master'
            }
        }
        stage('build') {
            steps {
                sh 'dotnet build'
            }
        }
    }
}