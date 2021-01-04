# Google Play data visualisation
This desktop application visualizes Googleplay datas by using Unity game engine. For scraping datas from Kaggle we need an API, ‌so we used Django Rest Framework to implement that. 
Dataset has been categorized in beck-end and API sends them to front-end.
In the 3D diagram, spheres represent records of our database (applications on Googleplay), by clicking on each of them, you can see more details.

## Features ##
 * 3D diagram
 * visualizing the most popular categories
 * showing details of each sphere of 3D diagram



## Technologies used ##
   * Unity game engine
   * DRF(Django Rest Framework)
    
## Who is it for? ##
  * Application developers who want to know more about Googleplay dataset
  * analysts
 
## API ## 

* <b>POST
</b>
<br>
Method: POST <br>
Data Format: JSON

```
Post Data Sample = {
        “application_name”: ““,
        “category_the_app_belongs”: ““,
        “overall_user_rating_of_the_app”: ““,
        “number_of_user_reviews_for_the_app”: ““,
        “size_of_the_app”: ““,
        “number_of_user_downloads_installs_for_the_app”: ““,
        “paid_or_free”: ““,
        “price_of_the_app”: ““,
        “age_group_the_app_is_targeted_at_children_mature_adult”: ““,
        “an_app_can_belong_to_multiple_genres”: ““,
    }
```
Post data to database using Post Method with provided data.
If you request post successfully you will receive a HTTP_200_OK response with a json like the example below:<br>

```
{“data“:“App Name“}
```
* <b>GET
</b>
<br>
Method: GET <br>
Data Format: JSON


This method will return all existing records in database in provided format:<br>

```
{“APP Name”:[“ Category”:” Category”, “OverallUserRating”:” OverallUserRating”, “NumberOfUsersReviews”:” NumberOfUsersReviews”, “Size”:” Size”, “NumberOfUserDownloads”:” NumberOfUserDownloads”, “PaidOrFree”:” PaidOrFree”, “Price”:” Price”, “AgeGroup”:” AgeGroup”, “Genres”:” Genres”]}
```

    



