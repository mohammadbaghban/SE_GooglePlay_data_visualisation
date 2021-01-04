from django.urls import path

from scraper import views

urlpatterns = [
    path('post', views.Post.as_view()),
    path('get', views.Get.as_view()),
    path('get_by_download', views.GetByFilterDownloadNumberAscending.as_view()),
]
