LinuxVhostsManager
==================

Help to manage vhosts on ubuntu server and synchronise file from a local folder

##What you can do

  - Create / Delete vhosts
  - Sync. file between local and dev server
  - Write into windows hosts file to point to dev server (Production/Development button)
  - Create/Open project from local file into Netbeans
  - Monitor in real time apache logs (error, access, rewrite, global)
  - Instantly replicate file modification from local to vhost dev server
  - Direct access to MySql Administration, local folder, website
  - Display Linux information (hdd space...)

##What you need

 - Ubuntu server 12.04 (can work with other distrib...)
 - SSH connection
 - Apache 2 with mode_rewrite
 - Samba share with a share named "vhosts" poiting to /var/www/vhosts
 - xdebug
 - PhpMyAdmin package
 - Access to config files or root access
 - On windows computer : Netbeans

**Install mod_rewrite**

```
sudo a2enmod rewrite
```

**Install mod_rewrite**

```
sudo apt-get install samba
sudo vim /etc/samba/smb.conf
```

*Add*
```
security = user

[vhosts]
    comment = VhostsApache
    path = /var/www/vhosts/
    browsable = yes
    guest ok = no
    read only = no
    create mask = 0755
```

**Install xdebug**

```
sudo apt-get install php5-xdebug
sudo vim /etc/php5/conf.d/xdebug.ini
```

*Add*
```
zend_extension=/usr/lib/php5/20090626/xdebug.so

xdebug.remote_enable=On
xdebug.remote_port=9000
xdebug.remote_handler=dbgp
xdebug.idkey="netbeans-xdebug"
xdebug.remote_connect_back=On
```


**Install PhpMyAdmin**

```
sudo apt-get install phpmyadmin
```

##Preview

<p align="center">
<img src="https://raw.github.com/dragouf/LinuxVhostsManager/master/screenshot1.png" alt="LinuxVhostManager screenshot options" />

<img src="https://raw.github.com/dragouf/LinuxVhostsManager/master/screenshot2.png" alt="LinuxVhostManager screenshot vhost" />
</p>
