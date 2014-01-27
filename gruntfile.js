module.exports = function(grunt) {
  require('load-grunt-tasks')(grunt);
  require('time-grunt')(grunt);

  grunt.initConfig({
  
    pkg: grunt.file.readJSON('package.json'),
  
    nugetpush: {
        dist: {
            src: 'test/*.nupkg'
        }
    },
    
    shell: {
        nugetpack: {
            options: {
                stdout: true
            },
            command: 'md pub & nuget pack EvolveSharp/EvolveSharp.csproj -Build -Prop Configuration=Release -OutputDirectory pub'
        }
    },
    
    assemblyinfo: {
        options: {
            files: ['EvolveSharp/EvolveSharp.csproj'],
            info: {
                title: '<%= pkg.name %>', 
                description: '<%= pkg.description %>', 
                configuration: 'Release', 
                company: '<%= pkg.author %>', 
                product: '<%= pkg.name %>', 
                copyright: 'Copyright © <%= pkg.author %> ' + (new Date().getYear() + 1900), 
                version: '<%= pkg.version %>.0', 
                fileVersion: '<%= pkg.version %>.0'
            }
        }
    }
    
  });
  grunt.registerTask('default', ['assemblyinfo', 'shell:nugetpack', 'nugetpush']);
};