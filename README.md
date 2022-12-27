# UnityWorkspace


## Server

BuildSetting��Platform: Dedicated Server Linux��Build��Upload server.zip


```bash
sudo docker build -t unity_server https://github.com/nagaohiroki/UnityWorkspace.git#main
sudo docker run -d -p 7777:7777 -p 7777:7777/udp unity_server
```


### Google Cloud Platform Setup Example

VM�C���X�^���X���l�b�g���[�N�C���^�t�F�[�X���l�b�g���[�N���t�@�C�A�E�H�[���u�t�@�C�A�E�H�[�����[����ǉ��v  
���O�^�O��:unity-server  
IPv4�͈�:0.0.0.0/0  
TCP:7777  
UDP:7777  

```
gcloud compute --project=discordaibot-371803 firewall-rules create unity-server --direction=INGRESS --priority=1000 --network=default --action=ALLOW --rules=tcp:7777,udp:7777 --source-ranges=0.0.0.0/0 --target-tags=unity-server
```


���s��ConnectionData.Address���C���X�^���X�̊O��ip�ɂ���