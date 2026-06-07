//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/loyalty_preview_line.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'loyalty_preview_request.g.dart';

abstract class LoyaltyPreviewRequest implements Built<LoyaltyPreviewRequest, LoyaltyPreviewRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'posId')
    String get posId;

    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @BuiltValueField(wireName: r'lines')
    BuiltList<LoyaltyPreviewLine> get lines;

    LoyaltyPreviewRequest._();

    static void _initializeBuilder(LoyaltyPreviewRequestBuilder b) => b;

    factory LoyaltyPreviewRequest([void updates(LoyaltyPreviewRequestBuilder b)]) = _$LoyaltyPreviewRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<LoyaltyPreviewRequest> get serializer => _$LoyaltyPreviewRequestSerializer();
}

class _$LoyaltyPreviewRequestSerializer implements StructuredSerializer<LoyaltyPreviewRequest> {

    @override
    final Iterable<Type> types = const [LoyaltyPreviewRequest, _$LoyaltyPreviewRequest];
    @override
    final String wireName = r'LoyaltyPreviewRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, LoyaltyPreviewRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'posId')
            ..add(serializers.serialize(object.posId,
                specifiedType: const FullType(String)));
        result
            ..add(r'customerId')
            ..add(serializers.serialize(object.customerId,
                specifiedType: const FullType(String)));
        result
            ..add(r'lines')
            ..add(serializers.serialize(object.lines,
                specifiedType: const FullType(BuiltList, [FullType(LoyaltyPreviewLine)])));
        return result;
    }

    @override
    LoyaltyPreviewRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = LoyaltyPreviewRequestBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'posId':
                    result.posId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'lines':
                    result.lines.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(LoyaltyPreviewLine)])) as BuiltList<LoyaltyPreviewLine>);
                    break;
            }
        }
        return result.build();
    }
}

