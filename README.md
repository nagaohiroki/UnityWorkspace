# UnityWorkspace


## Server

BuildSetting→Platform: Dedicated Server Linux→Build→Upload server.zip


```bash
sudo docker build -t unity_server https://github.com/nagaohiroki/UnityWorkspace.git#main
sudo docker run -d -p 7777:7777 -p 7777:7777/udp unity_server
```


### Google Cloud Platform Setup Example

VMインスタンス→ネットワークインタフェース→ネットワーク→ファイアウォール「ファイアウォールルールを追加」  
名前タグ名:unity-server  
IPv4範囲:0.0.0.0/0  
TCP:7777  
UDP:7777  

```
gcloud compute --project=discordaibot-371803 firewall-rules create unity-server --direction=INGRESS --priority=1000 --network=default --action=ALLOW --rules=tcp:7777,udp:7777 --source-ranges=0.0.0.0/0 --target-tags=unity-server
```


実行時ConnectionData.Addressをインスタンスの外部ipにする