## for local dev on minikube, 
to get ingress working. enable the ingress ip dns, and add it as local server per instruciton below.
```
https://minikube.sigs.k8s.io/docs/handbook/addons/ingress-dns/
```

1. install ingress dns
```
minikube addons enable ingress
minikube addons enable ingress-dns
```

2. add minikube ip as dns server locally
```
Add-DnsClientNrptRule -Namespace ".test" -NameServers "$(minikube ip)"
```